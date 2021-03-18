namespace API.Dtos
{
    public class SaveIngredientDto
    {
         public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public int IngredientBrandId { get; set; }
        public decimal Protein { get; set; }
        public decimal Calori { get; set; }
        public decimal Fat { get; set; }
    }
}