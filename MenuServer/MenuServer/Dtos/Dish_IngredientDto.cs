using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuServer.Dtos
{
    public class Dish_IngredientDto
    {
        public int DishId { get; set; }
        public int IngredientId { get; set; }
        public int AmountOfIngredient { get; set; }
    }
}
