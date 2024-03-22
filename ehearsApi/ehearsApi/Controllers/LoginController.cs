using ehearsApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Logging;
using System.Text;
using System.Security.Cryptography;
using ehearsApi.Data;
using Microsoft.EntityFrameworkCore;
using ehearsApi.Helpers;
using System.Security.Claims;

namespace ehearsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private readonly dhearsApiContext dbContext;
        public LoginController(IConfiguration configuration, dhearsApiContext dbContext)
        {
            _config = configuration;
            this.dbContext = dbContext;
        }

        private string GenerateToken(User users)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            // Ensure the key size is at least 256 bits
            var key = Encoding.ASCII.GetBytes("davaodelnortverysecret1234567890123456");

            var identity = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Role, users.Role),
            new Claim(ClaimTypes.Name, $"{users.Firstname} {users.Lastname}")
                });
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials,
            };

            return jwtTokenHandler.WriteToken(jwtTokenHandler.CreateToken(tokenDescription));
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User objUser)
        {
            IActionResult response = Unauthorized();

            if (objUser == null)
                return BadRequest();

            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Username == objUser.Username);

            if (user == null)
                return NotFound(new { Message = "User Not Found!" });

            if (!PasswordHasher.ViryfyPassword(objUser.Password, user.Password))
            {
                return BadRequest(new { Message = "Password is Incorrect"});
            }

            user.Token = GenerateToken(user);

            return Ok(new { Token = user.Token, Message = "Login Successful!" });
        }
    }
}
