using MenuServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuServer.Repositories
{
    public class MenuRepository : BaseRepository, IMenuRepository
    {
        public MenuRepository(MenuServerContext context) : base(context) { }

        public IEnumerable<Menu> FindAll()
        {
            return _context.Menu
                .Include(g => g.Dish)
                .Include(g => g.TimeOfDay)
                .Include(g => g.DayOfWeek);
        }

        public Menu FindById(int id)
        {
            return _context.Menu
                .Include(g => g.Dish)
                .Include(g => g.TimeOfDay)
                .Include(g => g.DayOfWeek)
                .FirstOrDefault(g => g.MenuId == id);
        }
        public void Add(Menu entity)
        {
            _context.Set<Menu>().Add(entity);
        }

        public void Update(Menu entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<Menu>().Update(entity);
        }

        public void Delete(Menu entity)
        {
            _context.Set<Menu>().Remove(entity);
        }

        public Menu Save(Menu entity)
        {
            _context.SaveChanges();
            return entity;
        }

        public bool EntityExists(int id)
        {
            return _context.Menu.Any(g => g.MenuId == id);
        }
    }
}
