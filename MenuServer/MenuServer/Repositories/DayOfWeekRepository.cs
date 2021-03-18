using MenuServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuServer.Repositories
{
    public class DayOfWeekRepository : BaseRepository, IDayOfWeekRepository
    {
        public DayOfWeekRepository(MenuServerContext context) : base(context) { }

        public IEnumerable<Models.DayOfWeek> FindAll()
        {
            return _context.DayOfWeek.OrderBy(a => a.DayOfWeekId);
        }

        public Models.DayOfWeek FindById(int id)
        {
            return _context.DayOfWeek.AsNoTracking().FirstOrDefault(a => a.DayOfWeekId == id);
        }

        public void Add(Models.DayOfWeek entity)
        {
            _context.Set<Models.DayOfWeek>().Add(entity);
        }

        public void Update(Models.DayOfWeek entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<Models.DayOfWeek>().Update(entity);
        }

        public void Delete(Models.DayOfWeek entity)
        {
            _context.Set<Models.DayOfWeek>().Remove(entity);
        }

        public Models.DayOfWeek Save(Models.DayOfWeek entity)
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
