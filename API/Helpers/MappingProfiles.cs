using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
             .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
             .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
             .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());

              CreateMap<Franchise, FranchiseToReturnDto>()
                .ForMember(d => d.Country, o => o.MapFrom(s => s.Country.Name))
                .ForMember(d => d.State, o => o.MapFrom(s => s.State.Name))
                .ForMember(d => d.PricingModel, o => o.MapFrom(s => s.PricingModel.Name))
                .ForMember(d => d.LogoUrl, o => o.MapFrom<FranchiseUrlResolver>());

                CreateMap<Core.Entities.Identity.Address, AddressDto>().ReverseMap();
                
        }
    }
}