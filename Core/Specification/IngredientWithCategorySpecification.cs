using Core.Entities;

namespace Core.Specification
{
    public class IngredientWithCategorySpecification : BaseSpecification<Ingredient>
    {
        public IngredientWithCategorySpecification(IngredientSpecParams ingredientParams) : base(x => (string.IsNullOrEmpty(ingredientParams.Search) || x.Name.ToLower().Contains(ingredientParams.Search)) &&
            (!ingredientParams.CategoryId.HasValue || x.IngredientCategoryId == ingredientParams.CategoryId))
        {
            AddInclude(x => x.IngredientCategory);
            AddOrderBy(x => x.Name);
            ApplyPaging(ingredientParams.PageSize * (ingredientParams.PageIndex - 1), ingredientParams.PageSize);

            if (!string.IsNullOrEmpty(ingredientParams.Sort))
            {
                switch (ingredientParams.Sort)
                {
                    case "proteinAsc":
                        AddOrderBy(p => p.Protein);
                        break;
                    case "proteinDesc":
                        AddOrderByDescending(p => p.Protein);
                        break;
                    // case "caloriAsc":
                    //     AddOrderBy(p => p.Calori);
                    //     break;
                    // case "caloriDesc":
                    //     AddOrderByDescending(p => p.Calori);
                    //     break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }
        public IngredientWithCategorySpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.IngredientCategory);
        }
    }
}