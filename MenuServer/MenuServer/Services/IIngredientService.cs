using MenuServer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuServer.Services
{
    public interface IIngredientService : IDataService<IngredientDto>
    {
        IEnumerable<IngredientDto> GetAll();
        bool CodeExists(int code);
        //IEnumerable<IngredientService> GetByDishId(int dishId);
    }
}
