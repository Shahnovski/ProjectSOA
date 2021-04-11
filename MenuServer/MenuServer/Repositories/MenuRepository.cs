using MenuServer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MenuServer.Repositories
{
    public class MenuRepository : BaseRepository, IMenuRepository
    {
        public MenuRepository(MenuServerContext context) : base(context) { }

        public IEnumerable<Menu> FindAll(string username)
        {
            return _context.Menu
                .Include(g => g.Dish)
                .ThenInclude(d => d.DishIngredients)
                .ThenInclude(di => di.Ingredient)
                .Include(g => g.TimeOfDay)
                .Include(g => g.DayOfWeek)
                .Where(g => g.Username.Equals(username));
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

        public void DeleteAll(string username)
        {
            Menu[] menus = FindAll(username).ToArray();
            _context.Set<Menu>().RemoveRange(menus);
        }

        public Menu Save(Menu entity)
        {
            _context.SaveChanges();
            return entity;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool EntityExists(int id)
        {
            return _context.Menu.Any(g => g.MenuId == id);
        }
    }
}
