using AutoMapper;
using Core.Entities;
using eCommerceAPI.DTOS;

namespace eCommerceAPI.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.PictureUrl, o=>o.MapFrom<ProductURLResolver>());
        }
    }
}
