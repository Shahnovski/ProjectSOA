using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuServer.Dtos
{
    public class TimeOfDayDto
    {
        public int TimeOfDayId { get; set; }
        public string TimeOfDayName { get; set; }
        public int MenuId { get; set; }
    }
}
