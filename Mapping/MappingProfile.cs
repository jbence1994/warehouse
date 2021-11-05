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
                .ForMember(productResource => productResource.MerchantName,
                    opt => opt.MapFrom(product => product.Merchant.Name));

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
