using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MenuServer.Models
{
    public class MenuServerContext : DbContext
    {
        public MenuServerContext (DbContextOptions<MenuServerContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Dish_Ingredient>().HasKey(a => new { a.DishId, a.IngredientId });

            modelBuilder.Entity<Dish_Ingredient>()
                .HasOne(gc => gc.Dish)
                .WithMany(g => g.DishIngredients)
                .HasForeignKey(gc => gc.DishId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            modelBuilder.Entity<Dish_Ingredient>()
                .HasOne(gc => gc.Ingredient)
                .WithMany(c => c.IngredientDish)
                .HasForeignKey(gc => gc.IngredientId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
        public DbSet<MenuServer.Models.Ingredient> Ingredient { get; set; }
        public DbSet<MenuServer.Models.DayOfWeek> DayOfWeek { get; set; }
        public DbSet<MenuServer.Models.Dish> Dish { get; set; }
        public DbSet<MenuServer.Models.Dish_Ingredient> Dish_Ingredient { get; set; }
        public DbSet<MenuServer.Models.Menu> Menu { get; set; }
        public DbSet<MenuServer.Models.TimeOfDay> TimeOfDay { get; set; }

    }
}
