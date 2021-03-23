using AutoMapper;
using MenuServer.Dtos;
using MenuServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuServer.MapperProfiles
{
    public class DishMapperProfile : Profile
    {
        public DishMapperProfile()
        {
            CreateMap<Dish, DishDto>().ForMember(dto => dto.Ingredients, g => g.MapFrom(g => g.DishIngredients.Select(
                    gc => new IngredientDto { IngredientId = gc.Ingredient.IngredientId, IngredientName = gc.Ingredient.IngredientName })));
            CreateMap<DishDto, Dish>();
        }
    }
}
