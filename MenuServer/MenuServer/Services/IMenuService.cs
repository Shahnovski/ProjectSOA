using MenuServer.Dtos;
using System.Collections.Generic;

namespace MenuServer.Services
{
    public interface IMenuService : IDataService<MenuDto>
    {
        IEnumerable<MenuDto> GetAll();

        void GetIngredientsFromCatalog(string url, DishDto dishDto);

        void GetIngredientsFromStore(string url, DishDto dishDto);
    }
}
