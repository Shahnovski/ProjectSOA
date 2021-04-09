using AutoMapper;
using MenuServer.Dtos;
using MenuServer.Models;
using System.Linq;

namespace MenuServer.MapperProfiles
{
    public class MenuMapperProfile : Profile
    {
        public MenuMapperProfile()
        {
            CreateMap<Menu, MenuDto>()
                .ForMember(dto => dto.Dish, m => m.MapFrom(
                    m => new DishDto { 
                    DishId = m.DishId,
                    DishName = m.Dish.DishName,
                    Ingredients = m.Dish.DishIngredients.Select(
                        i => new IngredientPlusDto
                        {
                            IngredientId = i.IngredientId,
                            IngredientName = i.Ingredient.IngredientName,
                            IngredientCode = i.Ingredient.IngredientCode,
                            Amount = i.AmountOfIngredient
                        })
                    }))
                .ForMember(dto => dto.DayOfWeekName, m => m.MapFrom(m => m.DayOfWeek.DayOfWeekName))
                .ForMember(dto => dto.TimeOfDayName, m => m.MapFrom(m => m.TimeOfDay.TimeOfDayName));
            CreateMap<MenuDto, Menu>();
        }
    }
}
