using MenuServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuServer.Dtos
{
    public class MenuDto
    {
        
        public int Id { get; set; }

        public IEnumerable<Dish> Dishes { get; set; }
        

        public MenuDto()
        {
            Dishes = new List<Dish>();
           
        }
    }
}
