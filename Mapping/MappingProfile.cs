using AutoMapper;
using Warehouse.Controllers.Resources;
using Warehouse.Core.Models;

namespace Warehouse.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductResource>();
            CreateMap<StockSummary, StockResource>();
            CreateMap<Supplier, KeyValuePairResource>();
        }
    }
}
