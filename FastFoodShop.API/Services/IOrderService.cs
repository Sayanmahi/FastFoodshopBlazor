using FastFoodShop.API.Models;
using FastFoodShop.API.Models.DTO.OrderDTO;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodShop.API.Services
{
    public interface IOrderService
    {
        Task<List<GetAllOrderDTO>> GetAllOrders();
        Task<List<GetAllOrderDTO>> GetOrdersNotDelivered();
        Task<bool> ValidateisDelieredOrder(int id);
        Task<bool> PlaceOrder(List<Order> orders);
        Task<List<MyOrder>> MyOrders(int id);
        Task<List<Order>> ShowMyUndeliveredOrders(int id);
        Task<bool> OrderIsPreparing(int id);

    }
}
