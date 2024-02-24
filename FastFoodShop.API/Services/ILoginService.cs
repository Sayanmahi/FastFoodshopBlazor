using FastFoodShop.API.Models;
using FastFoodShop.API.Models.DTO;

namespace FastFoodShop.API.Services
{
    public interface ILoginService
    {
        Task<string> LoginUser(LoginDTO l);
        Task<string> LoginAdmin(LoginDTO l);
        Task<bool> Register(User user);
    }
}
