using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MenuServer.Models
{
    public class DayOfWeek
    {
        [Key]
        public int DayOfWeekId { get; set; }
        
        [Required]
        public string DayOfWeekName { get; set; }

        [Required]
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}
