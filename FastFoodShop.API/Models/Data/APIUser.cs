using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FastFoodShop.API.Models.Data
{
    public class APIUser:IdentityUser
    {
      
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phno { get; set; }
    }
}
