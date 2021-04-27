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
            CreateMap<Supplier, SupplierWithProductsResource>();
            CreateMap<Supplier, KeyValuePairResource>();
            CreateMap<Stock, StockResource>();
            CreateMap<ProductPhoto, PhotoResource>();
            CreateMap<Technician, TechnicianResource>()
                .ForMember(technicianResource => technicianResource.Balance,
                    opt => opt.MapFrom(technician => technician.Balance.Amount));
            
            CreateMap<TechnicianPhoto, PhotoResource>();
            CreateMap<Sale, SaleResource>();
            CreateMap<SaleDetail, SaleDetailResource>();

            // API resource to model
            
            CreateMap<SaveStockResource, Stock>();
            CreateMap<SaveProductResource, Product>();
            CreateMap<SaveSaleResource, Sale>();
            CreateMap<SaveSaleDetailResource, SaleDetail>();
        }
    }
}
