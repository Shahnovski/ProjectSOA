using System.ComponentModel.DataAnnotations;

namespace MenuServer.Models
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public int TimeOfDayId { get; set; }
        public TimeOfDay TimeOfDay { get; set; }

        [Required]
        public int DayOfWeekId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

        [Required]
        public int DishId { get; set; }
        public Dish Dish { get; set; }

    }
}
