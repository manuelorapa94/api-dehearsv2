using ehearsApi.Data;
using ehearsApi.Helpers;
using ehearsApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

namespace ehearsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly dhearsApiContext dbContext;
        public UserController(dhearsApiContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await dbContext.Users.OrderBy(rt => rt.Lastname).ToListAsync());
        }

        [HttpGet]
        [Route("{UserId:guid}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid UserId)
        {
            var user = await dbContext.Users.FindAsync(UserId);

            if (user != null)
            {
                return Ok(user);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(Models.User objUser)
        {
            if (objUser == null)
                return BadRequest();

            if (await CheckUsernameExistAsync(objUser.Username))
                return BadRequest(new { Message = "Username already exist!" });

            if (await CheckEmailExistAsync(objUser.Email))
                return BadRequest(new { Message = "Email already exist!" });

            var pass = CheckPasswordStrength(objUser.Password);
            if (!string.IsNullOrEmpty(pass))
                return BadRequest(new { Message = pass.ToString() });

            var user = new User()
            {
                UserId = Guid.NewGuid(),
                Firstname = objUser.Firstname,
                Lastname = objUser.Lastname,
                Email = objUser.Email,
                Role = "user",
                Token = "none",
                Username = objUser.Username,
                Password = PasswordHasher.HashPassword(objUser.Password)
            };

            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();

            return Ok(user);
        }

        private Task<bool> CheckUsernameExistAsync(string Username)
            => dbContext.Users.AnyAsync(u => u.Username == Username);

        private Task<bool> CheckEmailExistAsync(string Email)
            => dbContext.Users.AnyAsync(u => u.Email == Email);

        private string CheckPasswordStrength(string password)
        {
            StringBuilder sb = new StringBuilder();
            if (password.Length < 8)
                sb.Append("Minimum password length should be 8 " + Environment.NewLine);

            if (!(Regex.IsMatch(password, "[a-z]") && Regex.IsMatch(password, "[A-Z]") && Regex.IsMatch(password, "\\d")))
                sb.Append("Password should be Alphanumeric " + Environment.NewLine);

            if (!Regex.IsMatch(password, @"[<>,@!#$%^&*()_+\[\]{}?:;|'\\.,/~`=]"))
                sb.Append("Password should contain special character " + Environment.NewLine);

            return sb.ToString();
        }


        [HttpPut]
        [Route("{UserId:guid}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid UserId, Models.User objUser)
        {
            var user = await dbContext.Users.FindAsync(UserId);

            if (user != null)
            {
                user.Firstname = objUser.Firstname;
                user.Lastname = objUser.Lastname;
                user.Email = objUser.Email;
                user.Role = objUser.Role;
                user.Username = objUser.Username;

                await dbContext.SaveChangesAsync();
                return Ok(user);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{UserId:guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid UserId)
        {
            var user = await dbContext.Users.FindAsync(UserId);

            if (user != null)
            {
                dbContext.Remove(user);
                await dbContext.SaveChangesAsync();
                return Ok(user);
            }

            return NotFound();
        }
    }
}
