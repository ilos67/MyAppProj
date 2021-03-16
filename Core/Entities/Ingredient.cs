using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("Ingredients")]
    public class Ingredient : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int IngredientCategoryId { get; set; }
        public IngredientCategory IngredientCategory { get; set; }
        public decimal? Protein { get; set; }
        public decimal? Calori { get; set; }
        public decimal? Fat { get; set; }
       
    }
}