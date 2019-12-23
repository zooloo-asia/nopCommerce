using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Orders;
using Nop.Core.Infrastructure.Mapper;
using Nop.Plugin.Rsc.Api.ComModels;
using Nop.Services.Catalog;
using Nop.Services.Customers;
using Nop.Services.Orders;
using IMapper = AutoMapper.IMapper;

namespace Nop.Plugin.Rsc.Api.Services
{
    public class RscShoppingCartService:IRscShoppingCartService
    {
        private IShoppingCartService _shoppingCartService;
        private ICustomerService _customerService;
        private IProductService _productService;
        private IHttpContextAccessor _httpContext;

        public RscShoppingCartService(IShoppingCartService shoppingCartService, ICustomerService customerService, IProductService productService, IHttpContextAccessor httpContext)
        {
            _shoppingCartService = shoppingCartService;
            _customerService = customerService;
            _productService = productService;
            _httpContext = httpContext;
        }

        public List<string> AddToCart(AddCartReq addCartReq)
        {
            var product = _productService.GetProductById(addCartReq.ProductId);
            var warningList = _shoppingCartService.AddToCart(GetFirstCustomer(), product, ShoppingCartType.ShoppingCart, 1,quantity:int.Parse(addCartReq.Quantity));
            return (List<string>) warningList;
        }

        public void RemoveFromCart(RemoveCartReq removeCartReq)
        {
            _shoppingCartService.DeleteShoppingCartItem(removeCartReq.CartItemId);
        }

        public IEnumerable<string> UpdateCart(UpdateCartReq updateCartReq)
        {
            return _shoppingCartService.UpdateShoppingCartItem(GetFirstCustomer(), updateCartReq.CartItemId, null, 0,
                quantity: updateCartReq.Quantity);
        }

        public IEnumerable<RscShoppingCartItem> GetCartItems()
        {
            var result = new List<RscShoppingCartItem>();
            var shoppingCartItems = _shoppingCartService.GetShoppingCart(GetFirstCustomer());
            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var rscShoppingCartItem = AutoMapperConfiguration.Mapper.Map<RscShoppingCartItem>(shoppingCartItem);
                var product = _productService.GetProductById(rscShoppingCartItem.ProductId);
                var rscProduct = AutoMapperConfiguration.Mapper.Map<RscShoppingCartItemProduct>(product);

                rscProduct.MaterialCode = product.ProductSpecificationAttributes
                    .FirstOrDefault(q => q.SpecificationAttributeOption.SpecificationAttribute.Name == "MaterialCode")
                    ?.CustomValue;
                rscProduct.LeadTime = Convert.ToInt32(product.ProductSpecificationAttributes
                    .FirstOrDefault(q => q.SpecificationAttributeOption.SpecificationAttribute.Name == "LeadTime")
                    ?.CustomValue);
                rscShoppingCartItem.Product = rscProduct;
                result.Add(rscShoppingCartItem);
                
            }

            return result;
        }

        private Customer GetFirstCustomer()
        {
            var userIdClaim = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            var customer =  _customerService.GetCustomerByEmail(userIdClaim.Value);
            return customer;
        }
    }
}