using FastFoodShop.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodShop.API.Services
{
    public class CategoryService : ICategoryService
    {
        public IActionResult AddCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public IActionResult DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public IActionResult EditCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        Task<bool> ICategoryService.AddCategory(Category category)
        {
            throw new NotImplementedException();
        }

        Task<bool> ICategoryService.DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        Task<bool> ICategoryService.EditCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
