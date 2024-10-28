using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;
using MyNewCiniesOction.BL;
using MyNewCiniesOction.Models;
using System.IdentityModel.Tokens.Jwt;

using System.Security.Claims;

using System.Text;

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.CodeDom.Compiler;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;



namespace MyNewCiniesOction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller { 
        private readonly IUserService _userService;
        private readonly IConfiguration configuration;
    public UserController(IUserService userService,IConfiguration configuration)
    {
        _userService = userService;
            this.configuration = configuration;
    }
        [HttpGet]
        public async Task<List<User>> Get()
        {
            try { 

            return await _userService.Get();

            }
            catch( Exception ex)
            {
                throw ex;
            }
        }

          
      
        [HttpDelete]
        public async Task<bool> Delete(int userId)
        {
            try
            {
                return await _userService.Delete(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpPut("/ForUser")]
        public async Task<bool> PutForUser(User user)
        {
            try
            {
                return await _userService.PutForUser(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpPut("/ForAdmin")]
        public async Task<bool> PutForAdmin(User user)
        {
            try
            {
                return await _userService.PutForAdmin(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpPost]
        public async Task<bool> Post(User user)
        {
            try
            {
                return await _userService.Post(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //======================================
        private string Generate(User user)
        {
            try { 
            string role;
            if (user.UserIsAdmin)
                role = "admin";
            else
                role = "customer";
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                 new Claim(ClaimTypes.Role, role),
                 new Claim("userId",user.UserId.ToString())
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = configuration["Jwt:Issuer"],
                Audience = configuration["Jwt:Audience"],

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };


            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;

        }
        catch(Exception ex)
            {
                throw ex;
            }
     }

        [HttpGet("userByEmailPassword")]

        public async Task<ActionResult<User>> GetUserByEmailAndPassword([FromQuery] string email, [FromQuery] string password)
        {
            try
            {
                User user = await _userService.GetUserByEmailAndPassword(email, password);
                if (user != null)
                {
                    var token = Generate(user);
                    if (token != null)
                    {
                        var jsonToken = JsonConvert.SerializeObject(new { token });
                        return Ok(jsonToken);
                    }
                   
                } 
                return NotFound("user not found");
            }
            
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }


      
    
}
