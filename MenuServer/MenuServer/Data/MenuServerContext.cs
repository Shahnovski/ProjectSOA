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

        public DbSet<MenuServer.Models.Ingredient> Ingredient { get; set; }
    }
}
