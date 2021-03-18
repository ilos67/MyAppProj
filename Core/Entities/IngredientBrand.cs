using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("IngredientBrands")]
    public class IngredientBrand : BaseEntity
    {
        public string Name { get; set; }
        public int IngredientCategoryId { get; set; }
        public IngredientCategory IngredientCategory { get; set; }
    }
}