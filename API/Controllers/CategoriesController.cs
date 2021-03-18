using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CategoriesController : BaseController
    {
        private readonly IGenericRepository<IngredientCategory> _ingredientCateRepo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CategoriesController(IGenericRepository<IngredientCategory> ingredientCateRepo, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _ingredientCateRepo = ingredientCateRepo;

        }

        
       [HttpGet]
       public async Task<ActionResult<IReadOnlyList<IngredientCategoryDto>>> GetCate ()
       {
           var ingredient = await _ingredientCateRepo.ListAllAsync();

           return _mapper.Map<IReadOnlyList<IngredientCategory>, List<IngredientCategoryDto>>(ingredient);
       }
    }
}