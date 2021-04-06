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

            CreateMap<IngredientPlusDto, IngredientToCartDto>().ForMember(dto => dto.CartItemCount, i => i.MapFrom(i => i.Amount));
        }
    }
}
