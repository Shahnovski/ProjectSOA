using MenuServer.Dtos;
using System.Collections.Generic;

namespace MenuServer.Services
{
    public interface IIngredientService : IDataService<IngredientDto>
    {
        IEnumerable<IngredientDto> GetAll();

        bool CodeExists(int code);
    }
}
