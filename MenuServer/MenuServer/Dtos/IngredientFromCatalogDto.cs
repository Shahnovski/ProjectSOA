using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuServer.Dtos
{
    public class IngredientFromCatalogDto
    {
        public int Id { get; set; }
        public int IngredientCode { get; set; }
        public string IngredientName { get; set; }
        public double IngredientCalories { get; set; }
        public double IngredientProteins { get; set; }
        public double IngredientCarbohydrates { get; set; }
        public double IngredientFats { get; set; }

    }
}
