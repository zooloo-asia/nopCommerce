using System.Collections.Generic;

namespace Nop.Plugin.Rsc.Api.ComModels
{
    public class RscShoppingCartItemProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrderMinimumQuantity { get; set; }
        public ICollection<int> CategoryIds { get; set; }
        public string MaterialCode { get; set; }
        public int LeadTime { get; set; }
    }
}