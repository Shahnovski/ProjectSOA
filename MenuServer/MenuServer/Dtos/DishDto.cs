using System.Collections.Generic;

namespace MenuServer.Dtos
{
    public class DishDto
    {
        public int DishId { get; set; }

        public string DishName { get; set; }

        public IEnumerable<IngredientPlusDto> Ingredients { get; set; }

        public DishDto()
        {
            Ingredients = new List<IngredientPlusDto>();
        }
    }
}
