using MenuServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuServer.Repositories
{
    public interface IIngredientRepository : IDataRepository<Ingredient>
    {
        IEnumerable<Ingredient> FindAll();

        Ingredient FindById(int id);

        bool EntityExists(int id);
    }
}
