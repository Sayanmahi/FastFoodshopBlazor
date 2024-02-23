using FastFoodShop.API.Context;
using FastFoodShop.API.Models;
using FastFoodShop.API.Models.DTO.OrderDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FastFoodShop.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly FoodDbContext _foodDbContext;
        public OrderService(FoodDbContext foodDbContext)
        {
            _foodDbContext = foodDbContext;
        }
        public async Task<List<GetAllOrderDTO>> GetAllOrders()
        {
            var data = await _foodDbContext.Orders.ToListAsync();
            List<GetAllOrderDTO> d= new List<GetAllOrderDTO>();
            if(data!= null)
            {
                foreach(var i in data)
                {
                    var da = await _foodDbContext.Users.FindAsync(i.UserId);
                    var itemname= await _foodDbContext.Items.FindAsync(i.ItemId);
                    var dto = new GetAllOrderDTO()
                    {
                        Id = i.Id,
                        Qty = i.Qty,
                        Price = i.Price,
                        ItemName = itemname.ProdName,
                        date = i.date,
                        isdelivered = i.isdelivered,
                        UserName = da.Name,
                        PhoneNo = da.PhoneNumber
                    };
                    d.Add(dto);
                }
            }
            return (d);
        }

        public async Task<List<GetAllOrderDTO>> GetOrdersNotDelivered()
        {
            var data = await _foodDbContext.Orders.Where(x => x.isdelivered == 1).ToListAsync();
            List<GetAllOrderDTO> d = new List<GetAllOrderDTO>();
            if (data != null)
            {
                foreach (var i in data)
                {
                    var da = await _foodDbContext.Users.FindAsync(i.UserId);
                    var itemname = await _foodDbContext.Items.FindAsync(i.ItemId);
                    var dto = new GetAllOrderDTO()
                    {
                        Id = i.Id,
                        Qty = i.Qty,
                        Price = i.Price,
                        ItemName = itemname.ProdName,
                        date = i.date,
                        isdelivered = i.isdelivered,
                        UserName = da.Name,
                        PhoneNo = da.PhoneNumber
                    };
                    d.Add(dto);
                }
            }
            return (d);
        }

        public async Task<List<Order>> MyOrders(int id)
        {
            var d= await _foodDbContext.Orders.Where(x => x.Id==id).ToListAsync();
            return d;
        }

        public async Task<bool> OrderIsPreparing(int id)
        {
            var d = await _foodDbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);
            d.isdelivered = 2;
            _foodDbContext.SaveChangesAsync();
            return (true);
        }

        public async Task<bool> PlaceOrder(List<Order> orders)
        {
            try {
                foreach(var i in orders)
                {
                    i.date = DateTime.Now;
                    await _foodDbContext.AddAsync(i);
                    await _foodDbContext.SaveChangesAsync();

                }
                return (true);
            }catch (Exception ex)
            {
                return (false);
            }
           
        }

        public async Task<List<MyOrder>> ShowMyUndeliveredOrders(int id)
        {
            var d = await _foodDbContext.Orders.Where(x => x.UserId == id && x.isdelivered == 1).ToListAsync();
            List<MyOrder> orders = new List<MyOrder>();
            if(d!=null)
            {
                foreach(var i in d)
                {
                    var c = await _foodDbContext.Items.FindAsync(i.ItemId);
                    var f = new MyOrder()
                    {
                        Id = i.Id,
                        Qty = i.Qty,
                        Price = i.Price,
                        ItemName = c.ProdName,
                        date = i.date,
                        isdelivered = i.isdelivered
                    };
                    orders.Add(f);
                }
            }
            return (orders);
        }

        public async Task<bool> ValidateisDelieredOrder(int id)
        {
            var d = await _foodDbContext.Orders.FindAsync(id);
            if(d!=null)
            {
                d.isdelivered = 0;
                await _foodDbContext.SaveChangesAsync();
                return (true);
            }
            else
            {
                return (false);
            }
        }

        Task<List<MyOrder>> IOrderService.MyOrders(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<Order>> IOrderService.ShowMyUndeliveredOrders(int id)
        {
            throw new NotImplementedException();
        }
    }
}
