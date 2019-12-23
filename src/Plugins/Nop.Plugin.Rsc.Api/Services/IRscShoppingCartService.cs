using System.Collections.Generic;
using Nop.Plugin.Rsc.Api.ComModels;

namespace Nop.Plugin.Rsc.Api.Services
{
    public interface IRscShoppingCartService
    {
        List<string> AddToCart(AddCartReq addCartReq);
        void RemoveFromCart(RemoveCartReq removeCartReq);
        IEnumerable<string> UpdateCart(UpdateCartReq updateCartReq);
        IEnumerable<RscShoppingCartItem> GetCartItems();
    }
}