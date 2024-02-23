using FastFoodShop.API.Models;
using FastFoodShop.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService db;
        public ItemController(IItemService db)
        {
            this.db = db;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddItem(Item item)
        {
            var d= await db.AddItem(item);
            return Ok(d);
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> EditItem(Item item)
        {
            var d= await db.EditItem(item);
            return Ok(d);
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> InactiveItem(int id)
        {
            var d = await db.InActiveItem(id);
            return Ok(d);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetItemsBasedOnCategory(int cid)
        {
            var d = await db.GetItemsBasedOnCategory(cid);
            return Ok(d);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllItems()
        {
            var d = await db.GetAllItems();
            return Ok(d);
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> ChangeCategory(int itemId,int categoryId)
        {
            var d = await db.ChangeCategory(itemId, categoryId);
            return Ok(d);
        }
    }
}
