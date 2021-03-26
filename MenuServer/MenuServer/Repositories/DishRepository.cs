using MenuServer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MenuServer.Repositories
{
    public class DishRepository : BaseRepository, IDishRepository
    {
        public DishRepository(MenuServerContext context) : base(context) { }

        public IEnumerable<Dish> FindAll()
        {
            return _context.Dish
                .OrderBy(g => g.DishName)
                .Include(g => g.DishIngredients)
                .ThenInclude(gp => gp.Ingredient);
        }

        public Dish FindById(int id)
        {
            return _context.Dish
                .OrderBy(g => g.DishName)
                .Include(g => g.DishIngredients)
                .ThenInclude(gp => gp.Ingredient)
                .FirstOrDefault(g => g.DishId == id);
        }

        public void Add(Dish entity)
        {
            _context.Set<Dish>().Add(entity);
        }

        public void Update(Dish entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<Dish>().Update(entity);
        }

        public void Delete(Dish entity)
        {
            _context.Set<Dish>().Remove(entity);
        }

        public Dish Save(Dish entity)
        {
            _context.SaveChanges();
            return entity;
        }

        public bool EntityExists(int id)
        {
            return _context.Dish.Any(g => g.DishId == id);
        }
    }
}
