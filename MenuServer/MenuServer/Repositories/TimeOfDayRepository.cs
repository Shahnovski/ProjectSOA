using MenuServer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MenuServer.Repositories
{
    public class TimeOfDayRepository : BaseRepository, ITimeOfDayRepository
    {
        public TimeOfDayRepository(MenuServerContext context) : base(context) { }

        public IEnumerable<TimeOfDay> FindAll()
        {
            return _context.TimeOfDay.OrderBy(a => a.TimeOfDayId);
        }

        public TimeOfDay FindById(int id)
        {
            return _context.TimeOfDay.AsNoTracking().FirstOrDefault(a => a.TimeOfDayId == id);
        }

        public TimeOfDay FindByName(string name)
        {
            return _context.TimeOfDay.AsNoTracking().FirstOrDefault(a => a.TimeOfDayName.Equals(name));
        }

        public void Add(TimeOfDay entity)
        {
            _context.Set<TimeOfDay>().Add(entity);
        }

        public void Update(TimeOfDay entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<TimeOfDay>().Update(entity);
        }

        public void Delete(TimeOfDay entity)
        {
            _context.Set<TimeOfDay>().Remove(entity);
        }

        public TimeOfDay Save(TimeOfDay entity)
        {
            _context.SaveChanges();
            return entity;
        }

        public bool EntityExists(int id)
        {
            return _context.TimeOfDay.Any(a => a.TimeOfDayId == id);
        }
    }
}
