using MenuServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuServer.Repositories
{
    public class TimeOfDayRepository : BaseRepository, ITimeOfDayRepository
    {
        public TimeOfDayRepository(MenuServerContext context) : base(context) { }

        public IEnumerable<Models.TimeOfDay> FindAll()
        {
            return _context.TimeOfDay.OrderBy(a => a.TimeOfDayId);
        }

        public Models.TimeOfDay FindById(int id)
        {
            return _context.TimeOfDay.AsNoTracking().FirstOrDefault(a => a.TimeOfDayId == id);
        }

        public void Add(Models.TimeOfDay entity)
        {
            _context.Set<Models.TimeOfDay>().Add(entity);
        }

        public void Update(Models.TimeOfDay entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<Models.TimeOfDay>().Update(entity);
        }

        public void Delete(Models.TimeOfDay entity)
        {
            _context.Set<Models.TimeOfDay>().Remove(entity);
        }

        public Models.TimeOfDay Save(Models.TimeOfDay entity)
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
