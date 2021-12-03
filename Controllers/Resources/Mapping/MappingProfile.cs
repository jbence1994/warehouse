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

            CreateMap<Product, GetProductRequestResource>()
                .ForMember(getProductRequestResource => getProductRequestResource.MerchantName,
                    options =>
                        options.MapFrom(product => product.Merchant.Name));

            CreateMap<Merchant, GetMerchantKeyValuePairWithProductKeyValuePairsResponseResource>();
            CreateMap<Merchant, GetKeyValuePairResponseResource>();
            CreateMap<Merchant, GetMerchantResponseResource>();
            CreateMap<Order, GetOrderResponseResource>();
            CreateMap<OrderDetail, GetOrderDetailResponseResource>();
            CreateMap<ProductPhoto, ProductPhotoResource>();
            CreateMap<Product, GetKeyValuePairResponseResource>();
            CreateMap<Supply, GetSupplyResponseResource>();
            CreateMap<SupplyEntry, GetSupplyEntryResponseResource>();
            CreateMap<Technician, GetTechnicianResponseResource>();
            CreateMap<TechnicianPhoto, PhotoResource>();

            // API request resources to models

            CreateMap<CreateMerchantRequestResource, Merchant>();
            CreateMap<CreateOrderRequestResource, Order>();
            CreateMap<CreateOrderDetailRequestResource, OrderDetail>();
            CreateMap<CreateProductRequestResource, Product>();
            CreateMap<CreateSupplyEntryRequestResource, SupplyEntry>();
            CreateMap<CreateTechnicianRequestResource, Technician>();
        }
    }
}
