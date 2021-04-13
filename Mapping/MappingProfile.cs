using AutoMapper;
using Warehouse.Controllers.Resources;
using Warehouse.Core.Models;

namespace Warehouse.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Model to API resource

            CreateMap<Product, ProductResource>()
                .ForMember(productResource => productResource.SupplierName,
                    opt => opt.MapFrom(product => product.Supplier.Name));

            CreateMap<StockSummary, StockSummaryResource>();
            CreateMap<Product, KeyValuePairResource>();
            CreateMap<Supplier, SupplierResource>();
            CreateMap<Stock, StockResource>();

            // API resource to model
            
            CreateMap<SaveStockResource, Stock>();
        }
    }
}
