using FastFoodShop.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodShop.API.Services
{
    public interface ICartService
    {
        IActionResult ShowMyCart();
        IActionResult AddToCart(Cart cart);
        IActionResult EditItem(Cart cart);
        IActionResult DeleteItem(int id);



    }
}
