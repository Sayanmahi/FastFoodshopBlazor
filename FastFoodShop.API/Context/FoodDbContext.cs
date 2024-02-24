using FastFoodShop.API.Models;
using FastFoodShop.API.Models.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FastFoodShop.API.Context
{
    public class FoodDbContext: IdentityDbContext<APIUser>
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get;set; }   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER",
                    Id = "151189ac-1c0c-4205-8321-0d1fc875b855"
                },
                new IdentityRole
                {
                    Name="Admin",
                    NormalizedName="ADMIN",
                    Id= "587d56d0-aa0b-4f28-b1fb-4e646fe3566e"
                });
            var hasher = new PasswordHasher<APIUser>();//hashes the password
            modelBuilder.Entity<APIUser>().HasData(
               new APIUser
               {
                   Id = "b0a68a4e-38e1-40ac-bbd7-312e36e25619",
                   Email = "admin@gmail.com",
                   NormalizedEmail = "ADMIN@GMAIL.COM",
                   Name = "Sayan Mukherjee",
                   UserName = "sayan",
                   NormalizedUserName = "SAYAN",
                   Phno= "7908502446",
                   PasswordHash = hasher.HashPassword(null, "Sayan@123"),
                   
               },
               new APIUser
               {
                   Id = "70a29864-7af3-4247-84ae-89ac78c0e6ba",
                   Email = "user@gmail.com",
                   NormalizedEmail = "USER@GMAIL.COM",
                   Name = "Tarun Mukherjee",
                   UserName = "tarun",
                   NormalizedUserName = "TARUN",
                   Phno="9051033177",
                   PasswordHash = hasher.HashPassword(null, "Tarun@123")
               });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "587d56d0-aa0b-4f28-b1fb-4e646fe3566e",
                UserId = "b0a68a4e-38e1-40ac-bbd7-312e36e25619"
            },
            new IdentityUserRole<string>
            {
                RoleId = "151189ac-1c0c-4205-8321-0d1fc875b855",
                UserId = "70a29864-7af3-4247-84ae-89ac78c0e6ba"
            }
            );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=FastFoodBlazor;");
        }
    }
}
