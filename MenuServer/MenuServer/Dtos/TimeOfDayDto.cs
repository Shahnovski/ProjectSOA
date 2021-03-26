using MenuServer.Models;
using System.Collections.Generic;

namespace MenuServer.Dtos
{
    public class TimeOfDayDto
    {
        public int TimeOfDayId { get; set; }
        public string TimeOfDayName { get; set; }

        public IEnumerable<Menu> Menus { get; set; }

        public TimeOfDayDto()
        {
            Menus = new List<Menu>();
        }
    }
}
