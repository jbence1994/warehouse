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

            CreateMap<Merchant, MerchantKeyValuePairWithProductKeyValuePairsResponse>();
            CreateMap<Merchant, KeyValuePairResponse>();
            CreateMap<Merchant, MerchantResponse>();
            CreateMap<Order, OrderResponse>();
            CreateMap<OrderDetail, OrderDetailResponse>();
            CreateMap<Product, ProductResponse>()
                .ForMember(getProductRequestResource => getProductRequestResource.MerchantName,
                    options =>
                        options.MapFrom(product => product.Merchant.Name));
            CreateMap<Product, KeyValuePairResponse>();
            CreateMap<ProductPhoto, ProductPhotoResponse>();
            CreateMap<Supply, SupplyResponse>();
            CreateMap<SupplyEntry, SupplyEntryResponse>();
            CreateMap<Technician, TechnicianResponse>();
            CreateMap<TechnicianPhoto, TechnicianPhotoResponse>();

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
