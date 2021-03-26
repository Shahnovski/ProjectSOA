using MenuServer.Dtos;
using System.Collections.Generic;

namespace MenuServer.Services
{
    public interface IMenuService : IDataService<MenuDto>
    {
        IEnumerable<MenuDto> GetAll();
    }
}
