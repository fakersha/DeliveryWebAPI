using DeliveryWebAPI.Domain.Models;
using DeliveryWebAPI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

//haha

namespace DeliveryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserValidator<User> _userValidator;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<User> _signInManager;

        public AccountController(
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IUserValidator<User> userValidator, 
            IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userValidator = userValidator;
            _configuration = configuration;
        }

        [HttpPost("LogOut")]
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
           
            await _signInManager.SignOutAsync();

            return Ok(new { Status = "Success", Message = "User Logout successfully!" });
        }


        private async Task<IActionResult> GetToken(User user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);


            var authClaims = new List<Claim>
            {
               new Claim(ClaimTypes.Name, user.UserName),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddHours(1),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterModel model)
        {
           

            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    UserName = model.PhoneNumber,
                    PhoneNumber = model.PhoneNumber,
                    Firstname = model.Firstname,
                    Lastname = model.Lastname
                };

                //var result = await _userValidator.ValidateAsync(_userManager, user);

                var result = await _userManager.CreateAsync(user, model.Password);


                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    return Ok(new { Status = "Success", Message = "რეგისტრაცია წარმატებით დასრულდა!" });
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }

            return Ok(new { Status = "Success", Message = "User created successfully!" });
        }

        
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
               
                var user = await _userManager.FindByNameAsync(model.PhoneNumber);
                if (user != null && !user.IsBlocked && !user.IsDeleted && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    var token = GetToken(user);
                    
                    return Ok(token.Result);

                }
            }
            return Unauthorized();
        }


        [HttpGet("rame")]
        [Authorize]
        public string test(string rame)
        {
            return rame;
        }
    }
}
