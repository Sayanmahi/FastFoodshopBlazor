using FastFoodShop.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FastFoodShop.API.Context
{
    public class FoodDbContext: DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get;set; }   
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=FastFoodBlazor;");
        }
    }
}
