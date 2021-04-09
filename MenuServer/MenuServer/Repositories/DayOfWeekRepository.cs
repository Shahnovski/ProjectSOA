using MenuServer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MenuServer.Repositories
{
    public class DayOfWeekRepository : BaseRepository, IDayOfWeekRepository
    {
        public DayOfWeekRepository(MenuServerContext context) : base(context) { }

        public IEnumerable<DayOfWeek> FindAll()
        {
            return _context.DayOfWeek.OrderBy(a => a.DayOfWeekId);
        }

        public DayOfWeek FindById(int id)
        {
            return _context.DayOfWeek.AsNoTracking().FirstOrDefault(a => a.DayOfWeekId == id);
        }

        public DayOfWeek FindByName(string name)
        {
            return _context.DayOfWeek.AsNoTracking().FirstOrDefault(a => a.DayOfWeekName.Equals(name));
        }

        public void Add(DayOfWeek entity)
        {
            _context.Set<DayOfWeek>().Add(entity);
        }

        public void Update(DayOfWeek entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<DayOfWeek>().Update(entity);
        }

        public void Delete(DayOfWeek entity)
        {
            _context.Set<DayOfWeek>().Remove(entity);
        }

        public DayOfWeek Save(DayOfWeek entity)
        {
            _context.SaveChanges();
            return entity;
        }

        public bool EntityExists(int id)
        {
            return _context.DayOfWeek.Any(a => a.DayOfWeekId == id);
        }
    }
}
