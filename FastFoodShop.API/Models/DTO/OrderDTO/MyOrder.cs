﻿namespace FastFoodShop.API.Models.DTO.OrderDTO
{
    public class MyOrder
    {
        public int Id { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }
        public string ItemName { get; set; }
        public DateTime date { get; set; }
        public int isdelivered { get; set; }
    }
}
