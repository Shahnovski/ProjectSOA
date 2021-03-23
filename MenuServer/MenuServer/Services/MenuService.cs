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
    }
}
