using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuServer.Repositories
{
    public interface ITimeOfDayRepository : IDataRepository<Models.TimeOfDay>
    {
        IEnumerable<Models.TimeOfDay> FindAll();

        Models.TimeOfDay FindById(int id);
    }
}
