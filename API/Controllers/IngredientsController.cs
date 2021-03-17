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
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public IngredientsController(IGenericRepository<Ingredient> ingredientRepo, IMapper mapper, IGenericRepository<IngredientCategory> ingredientCateRepo, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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


        [HttpGet("{id}", Name = "GetIngredient")]
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


        [HttpPost]
        public async Task<IActionResult> CreateIngredient([FromBody] SaveIngredientDto ingredientResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ingredient = _mapper.Map<SaveIngredientDto, Ingredient>(ingredientResource);

            _ingredientRepo.Add(ingredient);
            await _unitOfWork.Complete();

            ingredient = await _ingredientRepo.GetByIdAsync(ingredient.Id);

            var result = _mapper.Map<Ingredient, IngredientToReturnDto>(ingredient);

            return Ok(result);
        }

        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateIngredient(int id, [FromBody] SaveIngredientDto ingredientResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            

            var ingredient = await _ingredientRepo.GetByIdAsync(id);

            if(ingredient == null)
                return NotFound();
            _mapper.Map<SaveIngredientDto, Ingredient>(ingredientResource, ingredient);


            await _unitOfWork.Complete();

            ingredient = await _ingredientRepo.GetByIdAsync(ingredient.Id);

            var result = _mapper.Map<Ingredient, IngredientToReturnDto>(ingredient);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredient(int id)
        {
            var ingredient = await _ingredientRepo.GetByIdAsync(id);

            if (ingredient == null)
                return NotFound();

            _ingredientRepo.Delete(ingredient);
            if (await _unitOfWork.Complete() !=0) return Ok();

           return BadRequest("Problem deleting the ingredient");
        }


    }
}