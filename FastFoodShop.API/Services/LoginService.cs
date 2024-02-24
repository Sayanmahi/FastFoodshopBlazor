using FastFoodShop.API.Context;
using FastFoodShop.API.Controllers;
using FastFoodShop.API.Models;
using FastFoodShop.API.Models.Data;
using FastFoodShop.API.Models.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FastFoodShop.API.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILogger<AuthorizationController> logger;
        private readonly FoodDbContext db;
        private IConfiguration _config;

        public LoginService(ILogger<AuthorizationController> logger, FoodDbContext db, IConfiguration config)
        {
            this.logger = logger;
            this.db = db;
            _config = config;
        }
        public async Task<string> LoginAdmin(LoginDTO l)
        {
            var d = await db.Users.FirstOrDefaultAsync(x => x.Email == l.Email);
            if (d != null && d.userType=="Admin")
            {
                var dd = await db.Users.FirstOrDefaultAsync(x => x.Email == l.Email && x.Password == l.Password);
                if (dd != null)
                {
                    var token = JwtGenerate(l.Email, dd.userType, dd.Id);
                    return (token);
                }
                return ("Not");
            }
            return ("Not");
        }

        public async Task<string> LoginUser(LoginDTO l)
        {
            var d= await db.Users.FirstOrDefaultAsync(x=>x.Email == l.Email);   
            if(d!=null && d.userType=="User")
            {
                var dd= await db.Users.FirstOrDefaultAsync(x=>x.Email == l.Email && x.Password==l.Password);
                if(dd!=null)
                {
                    var token = JwtGenerate(l.Email, dd.userType, dd.Id);
                    return (token);
                }
                return ("Not");
            }
            return ("Not");
        }

        public async Task<bool> Register(User user)
        {
            var d= await db.Users.FirstOrDefaultAsync(x=>x.Email==user.Email);
            if(d==null)
            {
                await db.AddAsync(user);
                await db.SaveChangesAsync();
                return (true);
            }
            return (false);
        }
        private string JwtGenerate(string email, string role, int userid)
        {
            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256); //security key is public key so hashing security key
            var claims = new[]//dismantling the payload datas
            {
                 new Claim("Email",email),
                 new Claim("UserId",userid.ToString()),
                 new Claim(ClaimTypes.Role,role)
                };
            var token = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
