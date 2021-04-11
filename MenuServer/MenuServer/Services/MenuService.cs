using AutoMapper;
using MenuServer.Dtos;
using MenuServer.Models;
using MenuServer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace MenuServer.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IDayOfWeekRepository _dayOfWeekRepository;
        private readonly ITimeOfDayRepository _timeOfDayRepository;

        private readonly IMapper _mapper;

        public MenuService(
            IMenuRepository menuRepository,
            IDayOfWeekRepository dayOfWeekRepository,
            ITimeOfDayRepository timeOfDayRepository,
            IMapper mapper
            )
        {
            _menuRepository = menuRepository;
            _dayOfWeekRepository = dayOfWeekRepository;
            _timeOfDayRepository = timeOfDayRepository;
            _mapper = mapper;
        }

        public IEnumerable<MenuDto> GetAll(string username)
        {
            return _menuRepository.FindAll(username).Select(g => _mapper.Map<MenuDto>(g));
        }

        public MenuDto GetById(int id)
        {
            return _mapper.Map<MenuDto>(_menuRepository.FindById(id));
        }

        public MenuDto Save(int id, MenuDto dto)
        {
            Menu menu = _mapper.Map<Menu>(dto);
            if (id != 0)
            {
                menu.MenuId = id;
                menu.Dish = null;
                _menuRepository.Update(menu);
            }
            else
            {
                menu.DayOfWeekId = _dayOfWeekRepository.FindByName(dto.DayOfWeekName).DayOfWeekId;
                menu.TimeOfDayId = _timeOfDayRepository.FindByName(dto.TimeOfDayName).TimeOfDayId;
                menu.Dish = null;
                _menuRepository.Add(menu);
            }
            menu = _menuRepository.Save(menu);
            return GetById(menu.MenuId);
        }

        public void Delete(int id)
        {
            Menu menu = _menuRepository.FindById(id);
            _menuRepository.Delete(menu);
            _menuRepository.Save(menu);
        }

        public void DeleteAll(string username)
        {
            _menuRepository.DeleteAll(username);
            _menuRepository.Save();
        }

        public bool EntityExists(int id)
        {
            return _menuRepository.EntityExists(id);
        }

        public void GetIngredientsFromCatalog(string url, DishDto dishDto, string accessToken)
        {
            bool returnFlag = false;
            url += "?codes=";
            foreach (IngredientPlusDto ingredient in dishDto.Ingredients)
            {
                url += ingredient.IngredientCode.ToString();
                url += ",";
            }
            url = url.Remove(url.Length - 1);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.Substring(7));
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            List<IngredientFromCatalogDto> ingredientsFromCatalog = new List<IngredientFromCatalogDto>();
            client.SendAsync(request).ContinueWith(responseTask =>
            {
                string jsonIngredients = responseTask.Result.Content.ReadAsStringAsync().Result;
                jsonIngredients = jsonIngredients.Replace("\"i", "\"I");
                ingredientsFromCatalog.AddRange(JsonSerializer.Deserialize<List<IngredientFromCatalogDto>>(jsonIngredients));
                List<IngredientPlusDto> list = dishDto.Ingredients.ToList();
                foreach (IngredientPlusDto ingredientPlusDto in list)
                {
                    IngredientFromCatalogDto ingredientFromCatalog = ingredientsFromCatalog.FirstOrDefault(
                        i => i.IngredientCode == ingredientPlusDto.IngredientCode);
                    ingredientPlusDto.IngredientCalories = ingredientFromCatalog.IngredientCalories;
                    ingredientPlusDto.IngredientProteins = ingredientFromCatalog.IngredientProteins;
                    ingredientPlusDto.IngredientCarbohydrates = ingredientFromCatalog.IngredientCarbohydrates;
                    ingredientPlusDto.IngredientFats = ingredientFromCatalog.IngredientFats;
                }
                dishDto.Ingredients = list;
                returnFlag = true;
            });
            while (!returnFlag) { }
        }

        public void GetIngredientsFromStore(string url, DishDto dishDto, string accessToken)
        {
            bool returnFlag = false;
            url += "?codes=";
            foreach (IngredientPlusDto ingredient in dishDto.Ingredients)
            {
                url += ingredient.IngredientCode.ToString();
                url += ",";
            }
            url = url.Remove(url.Length - 1);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.Substring(7));
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            List<IngredientFromStoreDto> ingredientsFromCatalog = new List<IngredientFromStoreDto>();
            client.SendAsync(request).ContinueWith(responseTask =>
            {
                string jsonIngredients = responseTask.Result.Content.ReadAsStringAsync().Result;
                jsonIngredients = jsonIngredients.Replace("\"i", "\"I");
                ingredientsFromCatalog.AddRange(JsonSerializer.Deserialize<List<IngredientFromStoreDto>>(jsonIngredients));
                List<IngredientPlusDto> list = dishDto.Ingredients.ToList();
                foreach (IngredientPlusDto ingredientPlusDto in list)
                {
                    IngredientFromStoreDto ingredientFromCatalog = ingredientsFromCatalog.FirstOrDefault(
                        i => i.IngredientCode == ingredientPlusDto.IngredientCode);
                    ingredientPlusDto.IngredientCost = ingredientFromCatalog.IngredientPrice;
                }
                dishDto.Ingredients = list;
                returnFlag = true;
            });
            while (!returnFlag) { }
        }

        public void PostIngredientsToCart(string url, IEnumerable<DishDto> dishDtos, string accessToken)
        {
            List<IngredientToCartDto> ingredientsToCart = new List<IngredientToCartDto>();
            foreach (DishDto dishDto in dishDtos)
            {
                ingredientsToCart.AddRange(dishDto.Ingredients.Select(i => _mapper.Map<IngredientToCartDto>(i)));
            }
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.Substring(7));
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
            string jsonRequest = JsonSerializer.Serialize(ingredientsToCart);
            jsonRequest = jsonRequest.Replace("\"I", "\"i");
            jsonRequest = jsonRequest.Replace("\"C", "\"c");
            request.Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            client.SendAsync(request).ContinueWith(responseTask => {});
        }
    }
}
