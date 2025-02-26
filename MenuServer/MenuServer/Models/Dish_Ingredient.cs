﻿using System.ComponentModel.DataAnnotations;

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
        
        [Required]
        public int AmountOfIngredient { get; set; }
    }
}
