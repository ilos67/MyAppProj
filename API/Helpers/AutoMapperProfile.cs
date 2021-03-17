using API.Dtos;
using API.Dtos.Accounts;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;

namespace API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        // mappings between model and entity objects
        public AutoMapperProfile()
        {
            CreateMap<Account, AccountResponse>();

            CreateMap<Account, AuthenticateResponse>();

            CreateMap<RegisterRequest, Account>();

            CreateMap<CreateRequest, Account>();

            CreateMap<UpdateRequest, Account>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        // ignore null role
                        if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

                        return true;
                    }
                ));

                CreateMap<ProductBrand, KeyValuePairDto>();
                CreateMap<ProductType, KeyValuePairDto>();
                CreateMap<Ingredient, KeyValuePairDto>();
                CreateMap<IngredientCategory, KeyValuePairDto>();

                 CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());

                CreateMap<Ingredient, SaveIngredientDto>();

                CreateMap<Ingredient, IngredientToReturnDto>()
                // .ReverseMap();
                .ForMember(d => d.IngredientCategory, o => o.MapFrom(s => s.IngredientCategory.Name));


                // CreateMap<IngredientToReturnDto, Ingredient>()
                // .ForMember(d => d.IngredientCategory, o => o.MapFrom(s => s.IngredientCategory)); 

                CreateMap<SaveIngredientDto, Ingredient>()
                .ForMember(d => d.IngredientCategoryId, o => o.MapFrom(s => s.IngredientCategoryId));
                
         }
    }
}