using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuServer.Dtos
{
    public class DishDto
    {
        public int DishId { get; set; }
        public string DishName { get; set; }
        public int MenuId { get; set; }

        public IEnumerable<IngredientDto> Ingredients { get; set; }

        public DishDto()
        {
            Ingredients = new List<IngredientDto>();
        }
    }
}
