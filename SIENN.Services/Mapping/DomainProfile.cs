using System.Linq;
using AutoMapper;
using SIENN.DbAccess.Entities;
using SIENN.Services.DTO;

namespace SIENN.Services.Mapping
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            this.CreateMap<Category, CategoryDto>();
            this.CreateMap<Type, TypeDto>();
            this.CreateMap<Unit, UnitDto>();

            this.CreateMap<Product, ProductDto>()
                .ForMember(p => p.Categories, m => m.MapFrom(s => s.ProductCategories.Select(c => c.Category)));
        }
    }
}
