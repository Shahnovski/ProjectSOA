using MenuServer.Dtos;
using System.Collections.Generic;

namespace MenuServer.Services
{
    public interface IMenuService : IDataService<MenuDto>
    {
        IEnumerable<MenuDto> GetAll(string username);

        void DeleteAll(string username);

        void GetIngredientsFromCatalog(string url, DishDto dishDto, string accessToken);

        void GetIngredientsFromStore(string url, DishDto dishDto, string accessToken);

        void PostIngredientsToCart(string url, IEnumerable<DishDto> dishDtos, string accessToken);
    }
}
