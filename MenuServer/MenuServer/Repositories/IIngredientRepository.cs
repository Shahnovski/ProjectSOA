using MenuServer.Models;
using System.Collections.Generic;

namespace MenuServer.Repositories
{
    public interface IIngredientRepository : IDataRepository<Ingredient>
    {
        IEnumerable<Ingredient> FindAll();

        Ingredient FindById(int id, bool trackable);

        bool EntityExists(int id);

        bool CodeExists(int code);
    }
}
