using System.Collections.Generic;
using Nop.Plugin.Rsc.Api.ComModels;

namespace Nop.Plugin.Rsc.Api.Services
{
    public interface IRscProductService
    {
        IEnumerable<RscProduct> GetProducts(IEnumerable<int> ids);
        
    }
}