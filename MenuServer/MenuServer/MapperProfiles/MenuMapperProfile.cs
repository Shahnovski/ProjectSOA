using AutoMapper;
using MenuServer.Dtos;
using MenuServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
