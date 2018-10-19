using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GymManagement.Domain.Models.Resources;
using GymManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace GymManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork unitOfWork;

        public AuthController(IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            this._configuration = configuration;
            this.unitOfWork = unitOfWork;
        }
        [HttpPost, Route("login")]
        public IActionResult Login(LoginResource login)
        {
            
            if (unitOfWork.UserRepository.Get(login.Username, login.Password) != null)
            {
                return Ok(new { Token = GenerateToekn() });
            }

            return Unauthorized();
        }

        [HttpGet]
        public IActionResult sample()
        {
            return Ok();
        }
        private string GenerateToekn()
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("Url"),
                audience: _configuration.GetValue<string>("Url"),
                claims: new List<Claim>(),
                expires: DateTime.Now.AddDays(30),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }
    }
}