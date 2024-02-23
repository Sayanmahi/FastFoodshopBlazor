using FastFoodShop.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodShop.API.Services
{
    public interface IItemService
    {
        Task<bool> AddItem(Item item);
        Task<bool> EditItem(Item item);
        Task<bool> InActiveItem(int id);
        Task<List<Item>> GetItemsBasedOnCategory(int CategoryId);
        Task<List<Item>> GetAllItems();
        Task<bool> ChangeCategory(int itemId,int categoryId);
    }
}
