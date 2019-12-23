using System.Collections.Generic;

namespace Nop.Plugin.Rsc.Api.ComModels
{
    public class SimpleResp
    {
        public IEnumerable<string> Messages { get; set; } = new List<string>();
    }
}