using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MenuServer.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }
        
        [Required]
        public string DishName { get; set; }
       
        [Required]
        public IEnumerable<Dish_Ingredient> DishIngredients { get; set; }

        public Dish()
        {
            DishIngredients = new List<Dish_Ingredient>();
        }
    }
}
