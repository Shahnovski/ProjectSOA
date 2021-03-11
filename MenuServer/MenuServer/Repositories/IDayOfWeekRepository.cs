using System;
using System.Collections.Generic;
using MenuServer.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MenuServer.Repositories
{
    public interface IDayOfWeekRepository : IDataRepository<Models.DayOfWeek>
    {
        IEnumerable<Models.DayOfWeek> FindAll();

        Models.DayOfWeek FindById(int id);
    }
}
