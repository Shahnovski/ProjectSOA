using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [Required]
        public IEnumerable<Menu> Menus { get; set; }

        public Dish()
        {
            DishIngredients = new List<Dish_Ingredient>();
            Menus = new List<Menu>();
        }

        /*[Required]
        public int MenuId { get; set; }
        public Menu Menu { get; set; }*/
    }
}
