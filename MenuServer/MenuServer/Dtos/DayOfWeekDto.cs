using MenuServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuServer.Dtos
{
    public class DayOfWeekDto
    {
        public int DayOfWeekId { get; set; }
        public string DayOfWeekName { get; set; }
        public IEnumerable<Menu> Menus { get; set; }

        public DayOfWeekDto()
        {
            Menus = new List<Menu>();
        }
    }
}
