using FastFoodShop.API.Models;
using FastFoodShop.API.Models.DTO.OrderDTO;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodShop.API.Services
{
    public interface ICartService
    {
        Task<List<MyOrder>> ShowMyCart(int uid);
        Task<bool> AddToCart(Cart cart);
        Task<bool> EditItem(Cart cart);
        Task<bool> DeleteItem(int id);



    }
}
