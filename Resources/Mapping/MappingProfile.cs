using AutoMapper;
using Warehouse.Resources.Requests;
using Warehouse.Resources.Responses;
using Warehouse.Core.Models;

namespace Warehouse.Resources.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Model to API resource

            CreateMap<Product, GetProductRequestResource>()
                .ForMember(productResource => productResource.MerchantName,
                    memberOptions =>
                        memberOptions.MapFrom(product => product.Merchant.Name));

            CreateMap<Supply, SupplyResource>();
            CreateMap<Product, GetKeyValuePairResponseResource>();
            CreateMap<Merchant, GetMerchantKeyValuePairWithProductKeyValuePairsResponseResource>();
            CreateMap<Merchant, GetKeyValuePairResponseResource>();
            CreateMap<Merchant, GetMerchantResponseResource>();
            CreateMap<SupplyEntry, SupplyEntryResource>();
            CreateMap<ProductPhoto, ProductPhotoResource>();
            CreateMap<Technician, GetTechnicianResponseResource>();
            CreateMap<TechnicianPhoto, PhotoResource>();
            CreateMap<Order, OrderResource>();
            CreateMap<OrderDetail, OrderDetailResource>();

            // API resource to model

            CreateMap<CreateMerchantRequestResource, Merchant>();
            CreateMap<SaveSupplyEntryResource, SupplyEntry>();
            CreateMap<CreateProductRequestResource, Product>();
            CreateMap<SaveOrderResource, Order>();
            CreateMap<SaveOrderDetailResource, OrderDetail>();
            CreateMap<CreateTechnicianRequestResource, Technician>();
        }
    }
}
