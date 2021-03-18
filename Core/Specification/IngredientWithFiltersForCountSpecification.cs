using Core.Entities;

namespace Core.Specification
{
    public class IngredientWithFiltersForCountSpecification: BaseSpecification<Ingredient>
    {
        public IngredientWithFiltersForCountSpecification(IngredientSpecParams ingredientParams) : base(x => (string.IsNullOrEmpty(ingredientParams.Search) || x.Name.ToLower().Contains(ingredientParams.Search))&&
            (!ingredientParams.BrandId.HasValue || x.IngredientBrandId == ingredientParams.BrandId))
        {
            
        }
    }
}