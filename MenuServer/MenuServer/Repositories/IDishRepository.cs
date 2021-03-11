using MenuServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuServer.Repositories
{
    public interface IDishRepository : IDataRepository<Dish>
    {
        IEnumerable<Dish> FindAll();

        Dish FindById(int id);
    }
}
