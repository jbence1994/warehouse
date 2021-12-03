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

            CreateMap<Supply, SupplyResource>();
            CreateMap<Product, GetKeyValuePairResponseResource>();
            CreateMap<Merchant, GetMerchantKeyValuePairWithProductKeyValuePairsResponseResource>();
            CreateMap<Merchant, GetKeyValuePairResponseResource>();
            CreateMap<Merchant, GetMerchantResponseResource>();
            CreateMap<SupplyEntry, SupplyEntryResource>();
            CreateMap<ProductPhoto, ProductPhotoResource>();
            CreateMap<Technician, GetTechnicianResponseResource>();
            CreateMap<TechnicianPhoto, PhotoResource>();
            CreateMap<Order, GetOrderResponseResource>();
            CreateMap<OrderDetail, GetOrderDetailResponseResource>();

            // API request resources to models

            CreateMap<CreateMerchantRequestResource, Merchant>();
            CreateMap<SaveSupplyEntryResource, SupplyEntry>();
            CreateMap<CreateProductRequestResource, Product>();
            CreateMap<CreateOrderRequestResource, Order>();
            CreateMap<CreateOrderDetailRequestResource, OrderDetail>();
            CreateMap<CreateTechnicianRequestResource, Technician>();
        }
    }
}
