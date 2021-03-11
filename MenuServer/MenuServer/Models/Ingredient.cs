using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MenuServer.Models
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public int IngerientCode { get; set; }

        public IEnumerable<Dish_Ingredient> IngredientDish { get; set; }

        public Ingredient()
        {
            IngredientDish = new List<Dish_Ingredient>();
        }
    }
}
