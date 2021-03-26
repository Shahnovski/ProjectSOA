using MenuServer.Models;
using System.Collections.Generic;

namespace MenuServer.Repositories
{
    public interface IDishIngredientRepository : IDataRepository<Dish_Ingredient>
    {
        IEnumerable<Dish_Ingredient> FindByDishId(int dishId);
    }
}
