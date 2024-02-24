using FastFoodShop.API.Models;
using FastFoodShop.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService db;
        public OrderController(IOrderService db)
        {
            this.db = db;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllOrders()
        {
            var d =await db.GetAllOrders();
            return Ok(d);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetOrdersNotDelivered()
        {
            var d= await db.GetOrdersNotDelivered();
            return Ok(d);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> MyOrders(int cid)
        {
            var d= await db.MyOrders(cid);
            return Ok(d);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> PlaceOrders(List<Order> order)
        {
            var d = await db.PlaceOrder(order);
            return Ok(d);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetMyUndeliveredOrders(int id)
        {
            var d = await db.ShowMyUndeliveredOrders(id);
            return Ok(d);
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> Delivered(int id)
        {
            var d= await db.ValidateisDelieredOrder(id); 
            return Ok(d);   
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> OrderPreparing(int id)
        {
            var d = await db.OrderIsPreparing(id);
            return Ok();
        }

    }
}
