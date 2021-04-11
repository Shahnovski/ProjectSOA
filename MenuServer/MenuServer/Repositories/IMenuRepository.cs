using MenuServer.Models;
using System.Collections.Generic;

namespace MenuServer.Repositories
{
    public interface IMenuRepository : IDataRepository<Menu>
    {
        IEnumerable<Menu> FindAll(string username);

        Menu FindById(int id);

        bool EntityExists(int id);

        void DeleteAll(string username);

        void Save();
    }
}
