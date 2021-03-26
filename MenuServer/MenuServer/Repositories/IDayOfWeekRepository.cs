using System.Collections.Generic;

namespace MenuServer.Repositories
{
    public interface IDayOfWeekRepository : IDataRepository<Models.DayOfWeek>
    {
        IEnumerable<Models.DayOfWeek> FindAll();

        Models.DayOfWeek FindById(int id);
    }
}
