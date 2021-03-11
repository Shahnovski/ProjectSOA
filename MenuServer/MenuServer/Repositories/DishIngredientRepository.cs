using MenuServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuServer.Repositories
{
    public class DishIngredientRepository : BaseRepository, IDishIngredientRepository
    {
        public DishIngredientRepository(MenuServerContext context) : base(context) { }

        public IEnumerable<Dish_Ingredient> FindByDishId(int dishId)
        {
            return _context.Dish_Ingredient.Where(gc => gc.DishId == dishId).OrderBy(gc => gc.IngredientId);
        }

        public void Add(Dish_Ingredient entity)
        {
            _context.Set<Dish_Ingredient>().Add(entity);
        }

        public void Update(Dish_Ingredient entity)
        {
            _context.Set<Dish_Ingredient>().Update(entity);
        }

        public void Delete(Dish_Ingredient entity)
        {
            _context.Set<Dish_Ingredient>().Remove(entity);
        }

        public Dish_Ingredient Save(Dish_Ingredient entity)
        {
            _context.SaveChanges();
            return entity;
        }
    }
}
