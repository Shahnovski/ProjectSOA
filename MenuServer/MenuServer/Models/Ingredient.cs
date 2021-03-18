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
        public int IngredientId { get; set; }
        
        [Required]
        public string IngredientName { get; set; }
        
        [Required]
        public int IngredientCode { get; set; }

        public IEnumerable<Dish_Ingredient> IngredientDish { get; set; }

        public Ingredient()
        {
            IngredientDish = new List<Dish_Ingredient>();
        }
    }
}
