using AutoMapper;
using MenuServer.Dtos;
using MenuServer.Models;
using System.Linq;

namespace MenuServer.MapperProfiles
{
    public class DishMapperProfile : Profile
    {
        public DishMapperProfile()
        {
            CreateMap<Dish, DishDto>().ForMember(dto => dto.Ingredients, g => g.MapFrom(g => g.DishIngredients.Select(
                gc => new IngredientPlusDto { 
                    IngredientId = gc.Ingredient.IngredientId, 
                    IngredientName = gc.Ingredient.IngredientName, 
                    Amount = gc.AmountOfIngredient,
                    IngredientCode = gc.Ingredient.IngredientCode
                })));
            CreateMap<DishDto, Dish>();
        }
    }
}
