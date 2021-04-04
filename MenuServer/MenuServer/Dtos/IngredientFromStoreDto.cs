using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuServer.Dtos
{
    public class IngredientFromStoreDto
    {
        public int Id { get; set; }
        public int IngredientCode { get; set; }
        public string IngredientName { get; set; }
        public double IngredientPrice { get; set; }
    }
}
