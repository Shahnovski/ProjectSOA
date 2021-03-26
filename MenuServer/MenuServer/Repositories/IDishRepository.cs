using MenuServer.Models;
using System.Collections.Generic;

namespace MenuServer.Repositories
{
    public interface IDishRepository : IDataRepository<Dish>
    {
        IEnumerable<Dish> FindAll();

        Dish FindById(int id);

        bool EntityExists(int id);
    }
}
