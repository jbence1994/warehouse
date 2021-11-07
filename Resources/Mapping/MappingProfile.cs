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

            CreateMap<Product, ProductResource>()
                .ForMember(productResource => productResource.MerchantName,
                    memberOptions =>
                        memberOptions.MapFrom(product => product.Merchant.Name));

            CreateMap<Supply, SupplyResource>();
            CreateMap<Product, KeyValuePairResource>();
            CreateMap<Merchant, MerchantKeyValuePairWithProductKeyValuePairsResource>();
            CreateMap<Merchant, KeyValuePairResource>();
            CreateMap<Merchant, MerchantResource>();
            CreateMap<SupplyEntry, SupplyEntryResource>();
            CreateMap<ProductPhoto, ProductPhotoResource>();
            CreateMap<Technician, TechnicianResource>();
            CreateMap<TechnicianPhoto, PhotoResource>();
            CreateMap<Order, OrderResource>();
            CreateMap<OrderDetail, OrderDetailResource>();

            // API resource to model

            CreateMap<SaveMerchantResource, Merchant>();
            CreateMap<SaveSupplyEntryResource, SupplyEntry>();
            CreateMap<SaveProductResource, Product>();
            CreateMap<SaveOrderResource, Order>();
            CreateMap<SaveOrderDetailResource, OrderDetail>();
            CreateMap<SaveTechnicianResource, Technician>();
        }
    }
}
