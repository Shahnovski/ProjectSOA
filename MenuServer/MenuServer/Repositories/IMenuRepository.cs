using MenuServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuServer.Repositories
{
    public interface IMenuRepository : IDataRepository<Menu>
    {
        IEnumerable<Menu> FindAll();

        Menu FindById(int id);

        bool EntityExists(int id);
    }
}
