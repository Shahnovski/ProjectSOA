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
    }
}
