using MenuServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuServer.Dtos
{
    public class MenuDto
    {
        public int MenuId { get; set; }
        public int DayOfWeekId { get; set; }
        public int DishId { get; set; }
        public int TimeOfDayId { get; set; }

    }
}
