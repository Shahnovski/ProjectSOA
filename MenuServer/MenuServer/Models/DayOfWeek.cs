using System.Collections.Generic;
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
        public IEnumerable<Menu> Menu { get; set; }

        public DayOfWeek()
        {
            Menu = new List<Menu>();
        }
    }
}
