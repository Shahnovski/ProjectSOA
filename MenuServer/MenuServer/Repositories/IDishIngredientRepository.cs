using MenuServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuServer.Repositories
{
    public interface IDishIngredientRepository : IDataRepository<Dish_Ingredient>
    {
        IEnumerable<Dish_Ingredient> FindByDishId(int dishId);
    }
}
