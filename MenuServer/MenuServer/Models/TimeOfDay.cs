using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MenuServer.Models
{
    public class TimeOfDay
    {
        [Key]
        public int TimeOfDayId { get; set; }
        
        [Required]
        public string TimeOfDayName { get; set; }

        /*[Required]
        public int MenuId { get; set; }
        public Menu Menu { get; set; }*/
        [Required]
        public IEnumerable<Menu> Menu { get; set; }

        public TimeOfDay()
        {
            
            Menu = new List<Menu>();
        }
    }
}
