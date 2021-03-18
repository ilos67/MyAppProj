using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("IngredientCategories")]
    public class IngredientCategory : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<IngredientBrand> IngredientBrands { get; set; }

        public IngredientCategory()
        {
            IngredientBrands = new Collection<IngredientBrand>();
        }
    }
}