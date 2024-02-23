using FastFoodShop.API.Models;
using FastFoodShop.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService db;
        public CategoryController(ICategoryService db)
        {
            this.db = db;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddCategory(Category category)
        {
            var d= await db.AddCategory(category);
            return Ok(d);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCategories()
        {
            var d= await db.GetAllCategories();
            return Ok(d);
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> EditCategory(Category category)
        {
            var d = await db.EditCategory(category);
            return Ok(d);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var d= await db.GetCategoryById(id);
            return Ok(d);
        }
    }
}
