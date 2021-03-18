using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MenuServer.Dtos;
using MenuServer.Models;

namespace MenuServer.MapperProfiles
{
    public class IngredientMapperProfile : Profile 
    {
        public IngredientMapperProfile()
        {
            CreateMap<Ingredient, IngredientDto>();
            CreateMap<IngredientDto, Ingredient>();
        }
    }
}
