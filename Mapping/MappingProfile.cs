using AutoMapper;
using Warehouse.Controllers.Resources.Requests;
using Warehouse.Controllers.Resources.Responses;
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

            CreateMap<Stock, StockResource>()
                .ForMember(stockResource => stockResource.ProductName,
                    opt => opt.MapFrom(stock => stock.Product.Name))
                .ForMember(stockResource => stockResource.ProductSupplierName,
                    opt => opt.MapFrom(stock => stock.Product.Supplier.Name))
                .ForMember(stockResource => stockResource.ProductPrice,
                    opt => opt.MapFrom(stock => stock.Product.Price))
                .ForMember(stockResource => stockResource.ProductUnit,
                    opt => opt.MapFrom(stock => stock.Product.Unit));

            CreateMap<Product, KeyValuePairResource>();
            CreateMap<Supplier, SupplierKeyValuePairWithProductKeyValuePairsResource>();
            CreateMap<Supplier, KeyValuePairResource>();
            CreateMap<Supplier, SupplierResource>();
            CreateMap<StockEntry, StockEntryResource>();
            CreateMap<ProductPhoto, ProductPhotoResource>();
            CreateMap<Technician, TechnicianResource>();
            CreateMap<TechnicianPhoto, PhotoResource>();
            CreateMap<Order, OrderResource>();
            CreateMap<OrderDetail, OrderDetailResource>();

            // API resource to model

            CreateMap<SaveSupplierResource, Supplier>();
            CreateMap<SaveStockEntryResource, StockEntry>();
            CreateMap<SaveProductResource, Product>();
            CreateMap<SaveOrderResource, Order>();
            CreateMap<SaveOrderDetailResource, OrderDetail>();
            CreateMap<SaveTechnicianResource, Technician>();
        }
    }
}
