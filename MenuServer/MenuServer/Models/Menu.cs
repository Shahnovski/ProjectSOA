using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MenuServer.Models
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }

        public IEnumerable<Dish> Dishes { get; set; }
        public IEnumerable<TimeOfDay> Time { get; set; }
        public IEnumerable<DayOfWeek> Week { get; set; }

        public Menu()
        {
            Dishes = new List<Dish>();
            Time = new List<TimeOfDay>();
            Week = new List<DayOfWeek>();
        }
    }
}
