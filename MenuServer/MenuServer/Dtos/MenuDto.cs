namespace MenuServer.Dtos
{
    public class MenuDto
    {
        public int MenuId { get; set; }
        public int DayOfWeekId { get; set; }
        public int DishId { get; set; }
        public DishDto Dish { get; set; }
        public int TimeOfDayId { get; set; }
    }
}
