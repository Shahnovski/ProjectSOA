namespace MenuServer.Dtos
{
    public class IngredientPlusDto
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public int IngredientCode { get; set; }
        public int Amount { get; set; }

        public double IngredientCost { get; set; }
        public double IngredientCalories { get; set; }
        public double IngredientProteins { get; set; }
        public double IngredientCarbohydrates { get; set; }
        public double IngredientFats { get; set; }
    }
}
