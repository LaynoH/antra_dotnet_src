using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentication.API.Entities;
using Authentication.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        
        // register
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            var user = new User
            {
                Email = model.Email,
                FirstName = model.Email,
                LastName = model.LastName,
                UserName = model.Email
            };
            // save the user info to the user table
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Errors.Any())
            {
                return CreatedAtRoute("GetUser", new { controller = "account", id = user.Id });
            }

            return BadRequest(result.Errors.Select(error=>error.Description).ToList());
        }
        
        //login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new {error="Please check email/password format"});
            }

            var user = _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest("username does not exist");
            }

            var isAuthenticated = await _userManager.CheckPasswordAsync(await user, model.Password);
            if (isAuthenticated)
            {
                return Ok("username password valid");
            }

            return Unauthorized("username password is invalid");
        }

        //get user by id
    }
}
