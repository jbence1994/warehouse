using AutoMapper;
using Warehouse.Controllers.Resources.Requests;
using Warehouse.Controllers.Resources.Responses;
using Warehouse.Core.Models;

namespace Warehouse.Controllers.Resources.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Models to API response resources

            CreateMap<Merchant, GetMerchantKeyValuePairWithProductKeyValuePairsResponseResource>();
            CreateMap<Merchant, GetKeyValuePairResponseResource>();
            CreateMap<Merchant, GetMerchantResponseResource>();
            CreateMap<Order, GetOrderResponseResource>();
            CreateMap<OrderDetail, GetOrderDetailResponseResource>();
            CreateMap<Product, GetProductResponseResource>()
                .ForMember(getProductRequestResource => getProductRequestResource.MerchantName,
                    options =>
                        options.MapFrom(product => product.Merchant.Name));
            CreateMap<Product, GetKeyValuePairResponseResource>();
            CreateMap<ProductPhoto, GetProductPhotoResponseResource>();
            CreateMap<Supply, GetSupplyResponseResource>();
            CreateMap<SupplyEntry, GetSupplyEntryResponseResource>();
            CreateMap<Technician, GetTechnicianResponseResource>();
            CreateMap<TechnicianPhoto, GetTechnicianPhotoResponseResource>();

            // API request resources to models

            CreateMap<CreateMerchantRequest, Merchant>();
            CreateMap<CreateOrderRequest, Order>();
            CreateMap<CreateOrderDetailRequest, OrderDetail>();
            CreateMap<CreateProductRequest, Product>();
            CreateMap<CreateSupplyEntryRequest, SupplyEntry>();
            CreateMap<CreateTechnicianRequest, Technician>();
        }
    }
}
