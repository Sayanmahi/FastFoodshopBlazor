using FastFoodShop.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodShop.API.Services
{
    public class ItemService : IItemService
    {
        public IActionResult AddItem(Item item)
        {
            throw new NotImplementedException();
        }

        public IActionResult ChangeCategory(int itemId, int categoryId)
        {
            throw new NotImplementedException();
        }

        public IActionResult EditItem(Item item)
        {
            throw new NotImplementedException();
        }

        public IActionResult GetAllItems()
        {
            throw new NotImplementedException();
        }

        public IActionResult GetItemsBasedOnCategory(int Categoryid)//show only active Item
        {
            throw new NotImplementedException();
        }

        public IActionResult InActiveItem(int id)
        {
            throw new NotImplementedException();
        }
    }
}
