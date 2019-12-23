using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Rsc.Api.ComModels;
using Nop.Plugin.Rsc.Api.Services;

namespace Nop.Plugin.Rsc.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : Controller
    {
        private IRscShoppingCartService _shoppingCartService;

        public ShoppingCartController(IRscShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }
        [HttpPost]
        [Route("add")]
        public IActionResult AddToCart([FromBody]AddCartReq addCartReq)
        {
            var warnings = _shoppingCartService.AddToCart(addCartReq);
            return Ok(new SimpleResp(){Messages = warnings});
        }

        [HttpPost]
        [Route(("remove"))]
        public IActionResult RemoveFromCart([FromBody] RemoveCartReq removeCartReq)
        {
            _shoppingCartService.RemoveFromCart(removeCartReq);
            return Ok();
        }

        [HttpPost]
        [Route("update")]
        public IActionResult UpdateCart([FromBody] UpdateCartReq updateCartReq)
        {
            var warnings = _shoppingCartService.UpdateCart(updateCartReq);
            return Ok(new SimpleResp(){Messages = warnings});
        }

        [HttpGet]
        [Route("list")]
        public IActionResult ListCart()
        {
            return Ok(_shoppingCartService.GetCartItems());
        }
    }
}