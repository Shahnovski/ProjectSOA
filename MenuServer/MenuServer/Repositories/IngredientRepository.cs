using MenuServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuServer.Repositories
{
    public class IngredientRepository : BaseRepository, IIngredientRepository
    {
        public IngredientRepository(MenuServerContext context) : base(context) { }

        public IEnumerable<Ingredient> FindAll()
        {
            return _context.Ingredient.OrderBy(a => a.IngredientId);
        }

        public Ingredient FindById(int id)
        {
            return _context.Ingredient.AsNoTracking().FirstOrDefault(a => a.IngredientId == id);
        }

        public void Add(Ingredient entity)
        {
            _context.Set<Ingredient>().Add(entity);
        }

        public void Update(Ingredient entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<Ingredient>().Update(entity);
        }

        public void Delete(Ingredient entity)
        {
            _context.Set<Ingredient>().Remove(entity);
        }

        public Ingredient Save(Ingredient entity)
        {
            _context.SaveChanges();
            return entity;
        }

        public bool EntityExists(int id)
        {
            return _context.Ingredient.Any(a => a.IngredientId == id);
        }
    }
}
