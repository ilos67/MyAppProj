using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class IngredientToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string IngredientCategory { get; set; }
        public string IngredientBrand { get; set; }
        public decimal Protein { get; set; }
        public decimal Calori { get; set; }
        public decimal Fat { get; set; }
    }
}