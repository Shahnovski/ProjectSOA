using MenuServer.Models;
using System.Collections.Generic;

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
