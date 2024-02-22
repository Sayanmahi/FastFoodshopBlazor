using FastFoodShop.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodShop.API.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();
        Task<bool> EditCategory(Category category);
        Task<bool> AddCategory(Category category);
        Task<bool> DeleteCategory(int id);
    }
}
