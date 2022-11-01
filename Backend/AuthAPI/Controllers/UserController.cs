using AuthAPI.Data;
using AuthAPI.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _authContext;
        private readonly IConfiguration _config;
        public UserController(AppDbContext appDbContext, IConfiguration config)
        {
            _authContext = appDbContext;
            _config = config; 
        }

        [Authorize]
        [HttpGet("Get-Result")]
        public string GetResult(string token)
        {
                return "Res";
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate(User userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
               
            }
            var user = _authContext.Users.FirstOrDefault(x => x.Username == userObj.Username && x.Password == userObj.Password);

            if (user == null)
            {
                return NotFound(new { Message = "User Not Found" });
            }
            else
            {
                var token = GenerateToken(user.Username);
                return Ok(new
                {
                    Message = "Logged in successfully!",
                    JwtToken = token
                });
            }
            /*return Ok(new
            {
                Message = "Logged in successfully!"
            });*/        
        }
        

            [NonAction]
            private string GenerateToken(string username)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:key"]));
                var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var claims = new[]
                {
                    new Claim(ClaimTypes.UserData,username),
                    new Claim("Username", username)//enter username here
                };
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credential);

                return tokenHandler.WriteToken(token);
            }

        
    }
}
