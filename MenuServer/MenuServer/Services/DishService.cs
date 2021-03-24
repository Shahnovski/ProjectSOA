using AutoMapper;
using MenuServer.Dtos;
using MenuServer.Models;
using MenuServer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuServer.Services
{
    public class DishService : IDishService
    {
        private readonly IDishRepository _dishRepository;
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IDishIngredientRepository _dishIngredientRepository;
        private readonly IMapper _mapper;

        public DishService(
            IDishRepository dishRepository,
            IIngredientRepository ingredientRepository,
            IDishIngredientRepository dishIngredientRepository,
            IMapper mapper
            )
        {
            _dishRepository = dishRepository;
            _ingredientRepository = ingredientRepository;
            _dishIngredientRepository = dishIngredientRepository;
            _mapper = mapper;
        }

        public IEnumerable<DishDto> GetAll()
        {
            return _dishRepository.FindAll().Select(g => _mapper.Map<DishDto>(g));
        }

        public DishDto GetById(int id)
        {
            return _mapper.Map<DishDto>(_dishRepository.FindById(id));
        }

        public DishDto Save(int id, DishDto dto)
        {
            Dish dish = _mapper.Map<Dish>(dto);
            if (id != 0)
            {
                dish.DishId = id;
                _dishRepository.Update(dish);
            } else
            {
                _dishRepository.Add(dish);
            }
            dish = _dishRepository.Save(dish);
            ChangeDishIngredients(dish, dto);
            return GetById(dish.DishId);
        }

        public void Delete(int id)
        {
            Dish dish = _dishRepository.FindById(id);
            _dishRepository.Delete(dish);
            _dishRepository.Save(dish);
        }

        public bool EntityExists(int id)
        {
            return _dishRepository.EntityExists(id);
        }

        private void ChangeDishIngredients(Dish dish, DishDto dto)
        {
            IEnumerable<Dish_Ingredient> dishIngredients = _dishIngredientRepository.FindByDishId(dish.DishId);
            if (dishIngredients.Count() == 0)
            {
                foreach (IngredientPlusDto dishIngredient in dto.Ingredients)
                {
                    Ingredient ingredient = _ingredientRepository.FindById(dishIngredient.IngredientId);
                    Dish_Ingredient newDishIngredient = new Dish_Ingredient { Dish = dish, Ingredient = ingredient, AmountOfIngredient = dishIngredient.Amount }; 
                    _dishIngredientRepository.Add(newDishIngredient);
                }
            } else
            {
                foreach (IngredientPlusDto dishIngredient in dto.Ingredients)
                {
                    if (dishIngredients.All(gc => gc.IngredientId != dishIngredient.IngredientId))
                    {
                        Ingredient ingredient = _ingredientRepository.FindById(dishIngredient.IngredientId);
                        Dish_Ingredient newDishIngredient = new Dish_Ingredient { Dish = dish, Ingredient = ingredient, AmountOfIngredient = dishIngredient.Amount };
                        _dishIngredientRepository.Add(newDishIngredient);
                    }
                }
                foreach (Dish_Ingredient dishIngredient in dishIngredients)
                {
                    if (dto.Ingredients.All(c => c.IngredientId != dishIngredient.IngredientId))
                    {
                        _dishIngredientRepository.Delete(dishIngredient);
                    }
                }
            }
            _dishIngredientRepository.Save(null);
        }
    }
}
