using FastFoodShop.API.Models;
using FastFoodShop.API.Models.Data;
using FastFoodShop.API.Models.DTO;
using FastFoodShop.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FastFoodShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly ILogger<AuthorizationController> logger;
        private readonly UserManager<APIUser> userManager;
        private readonly ILoginService db;
        private IConfiguration _config;

        public AuthorizationController(ILogger<AuthorizationController> logger, UserManager<APIUser> userManager,IConfiguration config,ILoginService db)
        {
            this.logger = logger;
            this.userManager = userManager;
            _config = config;
            this.db = db;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            logger.LogInformation($"Registration attempt made for {userDTO.UserName}");
            var m = new APIUser()
            {
                Name = userDTO.UserName,
                Email = userDTO.Email,
                Phno = userDTO.PhoneNumber
            };
            m.UserName= userDTO.Email;
            var result=await userManager.CreateAsync(m, userDTO.Password);
            if(!result.Succeeded)
            {
                return BadRequest(result);
            }
            await userManager.AddToRoleAsync(m, "User");
            return Ok();
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> LoginUser(LoginDTO l )
        {
            logger.LogInformation($"Login attempt for {l.Email}");
            var user= await userManager.FindByEmailAsync(l.Email);
            var passwordValid = await userManager.CheckPasswordAsync(user, l.Password);
            if (user==null || passwordValid==false)
            {
                return NotFound();
            }
            return Accepted();

        }
        [HttpPost("[action]")]
        public async Task<IActionResult> LoginnUser(LoginDTO l)
        {
            var d = await db.LoginUser(l);
            if(d=="Not")
            {
                return NotFound();
            }
            return Ok(d);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> LoginnAdmin(LoginDTO l)
        {
            var d = await db.LoginAdmin(l);
            if (d == "Not")
            {
                return NotFound();
            }
            return Ok(d);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Registerr(User l)
        {
            var d = await db.Register(l);
            if (d == false)
            {
                return NotFound();
            }
            return Ok(d);
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
