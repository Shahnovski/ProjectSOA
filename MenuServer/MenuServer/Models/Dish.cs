﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MenuServer.Models
{
    public class Dish
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
       
        [Required]
        public IEnumerable<Dish_Ingredient> DishIngredients { get; set; }

        public Dish()
        {
            DishIngredients = new List<Dish_Ingredient>();
        }


        [Required]
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}
