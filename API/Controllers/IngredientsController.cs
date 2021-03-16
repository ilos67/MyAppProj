using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class IngredientsController : BaseController
    {
        private readonly IGenericRepository<Ingredient> _ingredientRepo;
        private readonly IGenericRepository<IngredientCategory> _ingredientCateRepo;

        private readonly IMapper _mapper;
        public IngredientsController(IGenericRepository<Ingredient> ingredientRepo, IMapper mapper, IGenericRepository<IngredientCategory> ingredientCateRepo)
        {
            _ingredientCateRepo = ingredientCateRepo;
            _ingredientRepo = ingredientRepo;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult<Pagination<IngredientToReturnDto>>> GetIngredient(
           [FromQuery] IngredientSpecParams ingredientParams)
        {
            var spec = new IngredientWithCategorySpecification(ingredientParams);

            var countSpec = new IngredientWithFiltersForCountSpecification(ingredientParams);

            var totalItems = await _ingredientRepo.CountAsync(countSpec);

            var ingredients = await _ingredientRepo.ListAsync(spec);

            var data = _mapper
                .Map<IReadOnlyList<Ingredient>, IReadOnlyList<IngredientToReturnDto>>(ingredients);

            return Ok(new Pagination<IngredientToReturnDto>(ingredientParams.PageIndex, ingredientParams.PageSize, totalItems, data));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientToReturnDto>> GetIngredient(int id)
        {
            var spec = new IngredientWithCategorySpecification(id);

            var ingredient = await _ingredientRepo.GetEntityWithSpec(spec);

            if (ingredient == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Ingredient, IngredientToReturnDto>(ingredient);
        }


        [HttpGet("categories")]
        public async Task<ActionResult<IReadOnlyList<IngredientCategory>>> GetIngredientCategory()
        {
            return Ok(await _ingredientCateRepo.ListAllAsync());
        }

    }
}