namespace MenuServer.Dtos
{
    public class MenuDto
    {
        public int MenuId { get; set; }

        public string Username { get; set; }

        public int DayOfWeekId { get; set; }
        public string DayOfWeekName { get; set; }

        public int DishId { get; set; }

        public DishDto Dish { get; set; }

        public int TimeOfDayId { get; set; }
        public string TimeOfDayName { get; set; }
    }
}
