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

            modelBuilder.Entity<Menu>().HasAlternateKey(rm => new { rm.DayOfWeekId, rm.TimeOfDayId });

            modelBuilder.Entity<Menu>()
             .HasOne(rm => rm.DayOfWeek)
             .WithMany(r => r.Menu)
             .HasForeignKey(rm => rm.DayOfWeekId)
             .OnDelete(DeleteBehavior.Cascade)
             .IsRequired();

            modelBuilder.Entity<Menu>()
            .HasOne(rm => rm.TimeOfDay)
            .WithMany(r => r.Menu)
            .HasForeignKey(rm => rm.TimeOfDayId)
            .OnDelete(DeleteBehavior.Cascade)
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
