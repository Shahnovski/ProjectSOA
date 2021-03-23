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
        public int MenuId { get; set; }


        [Required]
        public int TimeOfDayId { get; set; }
        public TimeOfDay TimeOfDay { get; set; }

        [Required]
        public int DayOfWeekId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

        [Required]
        public int DishId { get; set; }
        public Dish Dish { get; set; }

        //public IEnumerable<Dish> Dishes { get; set; }
        //public IEnumerable<TimeOfDay> Time { get; set; }
        //public IEnumerable<DayOfWeek> Week { get; set; }

        public Menu()
        {
            //Dishes = new List<Dish>();
            //Time = new List<TimeOfDay>();
            //Week = new List<DayOfWeek>();
        }
    }
}
