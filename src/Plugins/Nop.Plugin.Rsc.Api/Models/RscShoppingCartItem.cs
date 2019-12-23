
using Nop.Core.Domain.Orders;

namespace Nop.Plugin.Rsc.Api.ComModels
{
    public class RscShoppingCartItem
    {
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public RscShoppingCartItemProduct Product { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}