using FastFoodShop.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodShop.API.Services
{
    public interface IItemService
    {
        IActionResult AddItem(Item item);
        IActionResult EditItem(Item item);
        IActionResult InActiveItem(int id);
        IActionResult GetItemsBasedOnCategory(int CategoryId);
        IActionResult GetAllItems();
        IActionResult ChangeCategory(int itemId,int categoryId);
    }
}
