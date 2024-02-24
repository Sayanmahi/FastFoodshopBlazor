using System.ComponentModel.DataAnnotations;

namespace FastFoodShop.API.Models.DTO
{
    public class UserDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}
