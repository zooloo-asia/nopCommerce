using AutoMapper;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Orders;
using Nop.Core.Infrastructure.Mapper;
using Nop.Plugin.Rsc.Api.ComModels;

namespace Nop.Plugin.Rsc.Api
{
    public class MapperConfig:Profile,IOrderedMapperProfile
    {
        public MapperConfig()
        {
            CreateMap<ShoppingCartItem, RscShoppingCartItem>()
                .ForMember(f=>f.ProductName,
                    opt=>opt.MapFrom(s=>s.Product.Name))
                .ForMember(f=>f.CartItemId,opt=>opt
                    .MapFrom(f=>f.Id));
            CreateMap<Product, RscShoppingCartItemProduct>();
            CreateMap<Product, RscProduct>();
            

        }

        public int Order => 1;
    }
}