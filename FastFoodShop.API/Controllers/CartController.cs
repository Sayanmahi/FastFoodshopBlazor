using FastFoodShop.API.Models;
using FastFoodShop.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService db;
        public CartController(ICartService db)
        {
            this.db = db;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddToCart(Cart cart)
        {
            var d = await db.AddToCart(cart);
            return Ok(d);

        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var d= await db.DeleteItem(id);
            return Ok(d);
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> EditItem(Cart cart)
        {
            var d = await db.EditItem(cart);
            return Ok(d);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> ShowMyCart(int uid)
        {
            var d = await db.ShowMyCart(uid);
            return Ok(d);
        }
    }
}
