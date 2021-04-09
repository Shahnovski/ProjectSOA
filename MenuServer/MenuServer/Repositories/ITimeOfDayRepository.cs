using System.Collections.Generic;

namespace MenuServer.Repositories
{
    public interface ITimeOfDayRepository : IDataRepository<Models.TimeOfDay>
    {
        IEnumerable<Models.TimeOfDay> FindAll();

        Models.TimeOfDay FindById(int id);

        Models.TimeOfDay FindByName(string name);
    }
}
