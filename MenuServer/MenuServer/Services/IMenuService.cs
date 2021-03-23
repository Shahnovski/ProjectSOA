using MenuServer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuServer.Services
{
    public interface IMenuService : IDataService<MenuDto>
    {
        IEnumerable<MenuDto> GetAll();
    }
}
