using Microsoft.AspNetCore.Mvc;

namespace Nop.Plugin.Rsc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        
        [Route("test")]
        public IActionResult Index()
        {
            return Ok(new {msg="test"});
        }
    }
}