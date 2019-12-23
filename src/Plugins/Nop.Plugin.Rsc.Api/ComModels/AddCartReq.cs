using System.Collections.Generic;

namespace Nop.Plugin.Rsc.Api.ComModels
{
    public class AddCartReq
    {
        public int ProductId { get; set; }
        public string Quantity { get; set; }
    }
}