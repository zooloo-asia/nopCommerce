using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Rsc.Api.ComModels;
using Nop.Plugin.Rsc.Api.Services;

namespace Nop.Plugin.Rsc.Api.Controllers
{
//    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController:Controller
    {
        private IRscProductService _rscProductService;

        public ProductController(IRscProductService rscProductService)
        {
            _rscProductService = rscProductService;
        }

        [HttpPost]
        [Route("GetProducts")]
        public IActionResult GetProducts([FromBody] IdListReq idListReq)
        {
            return Ok(_rscProductService.GetProducts(idListReq.Ids));
        }
    }
}