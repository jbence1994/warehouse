using AutoMapper;
using Warehouse.Controllers.Resources;
using Warehouse.Core.Models;

namespace Warehouse.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductResource>()
                .ForMember(productResource => productResource.SupplierName,
                    opt => opt.MapFrom(product => product.Supplier.Name));

            CreateMap<StockSummary, StockResource>();
        }
    }
}
