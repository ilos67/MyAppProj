using System.Collections.Generic;
using System.Collections.ObjectModel;
using Core.Entities;

namespace API.Dtos
{
    public class IngredientCategoryDto : KeyValuePairDto
    {
        public ICollection<IngredientBrand> IngredientBrands { get; set; }

        public IngredientCategoryDto()
        {
            IngredientBrands = new Collection<IngredientBrand>();
        }

    }
}