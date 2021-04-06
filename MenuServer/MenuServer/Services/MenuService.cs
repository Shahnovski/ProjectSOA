using AutoMapper;
using MenuServer.Dtos;
using MenuServer.Models;
using MenuServer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MenuServer.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        
        private readonly IMapper _mapper;

        public MenuService(
            IMenuRepository menuRepository,
            IMapper mapper
            )
        {
            _menuRepository = menuRepository;
            _mapper = mapper;
        }

        public IEnumerable<MenuDto> GetAll()
        {
            return _menuRepository.FindAll().Select(g => _mapper.Map<MenuDto>(g));
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
                _menuRepository.Update(menu);
            }
            else
            {
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

        public bool EntityExists(int id)
        {
            return _menuRepository.EntityExists(id);
        }

        public void GetIngredientsFromCatalog(string url, DishDto dishDto)
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

        public void GetIngredientsFromStore(string url, DishDto dishDto)
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
    }
}
