﻿using MenuServer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MenuServer.Repositories
{
    public class IngredientRepository : BaseRepository, IIngredientRepository
    {
        public IngredientRepository(MenuServerContext context) : base(context) { }

        public IEnumerable<Ingredient> FindAll()
        {
            return _context.Ingredient.OrderBy(a => a.IngredientId);
        }

        public Ingredient FindById(int id, bool trackable)
        {
            if (trackable)
                return _context.Ingredient.FirstOrDefault(a => a.IngredientId == id);
            else
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

        public bool CodeExists(int code)
        {
            return _context.Ingredient.Any(a => a.IngredientCode == code);
        }
    }
}
