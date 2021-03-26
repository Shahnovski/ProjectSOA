using AutoMapper;
using MenuServer.Dtos;
using MenuServer.Models;

namespace MenuServer.MapperProfiles
{
    public class MenuMapperProfile : Profile
    {
        public MenuMapperProfile()
        {
            CreateMap<Menu, MenuDto>();
            CreateMap<MenuDto, Menu>();
        }
    }
}
