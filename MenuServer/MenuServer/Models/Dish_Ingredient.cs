using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MenuServer.Models
{
    public class Dish_Ingredient
    {
        [Key]
        public int DishId { get; set; }
        public Dish Dish { get; set; }

        [Key]
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }

        public int AmountOfIngredient { get; set; }
    }
}
