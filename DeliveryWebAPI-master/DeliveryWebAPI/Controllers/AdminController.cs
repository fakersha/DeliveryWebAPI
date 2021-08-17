using AutoMapper;
using DeliveryWebAPI.Domain.Models;
using DeliveryWebAPI.Models.FrontMappedModels;
using DeliveryWebAPI.Services.Abstractions;
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

namespace DeliveryWebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminServices _adminServices;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IBranchService _branchService;


        public AdminController(
            IBranchService branchService,
            IConfiguration configuration,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            IAdminServices adminServices,
            IMapper mapper)
        {
            _branchService = branchService;
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
            _adminServices = adminServices;
            _mapper = mapper;
        }


        [HttpPut("UpdateCategory")]
        public IActionResult UpdateCategory(int Id, string CategoryName)
        {
            var category = _adminServices.GetCategoryById(Id);
            if (category != null)
            {
                category.Name = CategoryName;
                var result = _adminServices.UpdateCategory(category).Result;
                if (result)
                {
                   
                    return Ok(new { Status = "Success", Message = "კატეგორია წამრატებით დააფდეითდა!" });
                }

            }
            return BadRequest(new { Status = "Failed", Message = "კატეგორია ვერ დააფდეითდა!" });

        }


        [HttpPost("AddCategory")]
        public IActionResult AddCategory(string category)
        {
            Category Categoryforadd = new Category { Name = category };
            _adminServices.AddCategory(Categoryforadd);
            return Ok();
        }


        [HttpPost("RemoveCategory")]
        public IActionResult RemoveCategory(int Id)
        {
            var result =_adminServices.RemoveCategoryById(Id);
            if (result.Result)
            {
                return Ok(new { Status = "Success", Message = "კატეგორია წამრატებით წაიშალა!" });
            }

            return BadRequest(new { Status = "Failed", Message = "კატეგორია ვერ მოიძებნა!" });
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

        
        [HttpPost("Login")]
        public async Task<IActionResult> Login(AdminLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    var isInRole = await _userManager.IsInRoleAsync(user, "Admin");
                    if (isInRole)
                    {
                        //var userRoles = await _userManager.GetRolesAsync(user);

                        var token = await GetToken(user);
                        
                        return Ok(token);

                    }
                    else
                    {
                        return Unauthorized();
                    }
                    
                }
            }
            return Unauthorized();
        } 


        [Authorize (Roles ="Admin")]
        [HttpPut("BlockUser")]
        public IActionResult Block(string phoneNumber)
        {
            _adminServices.BlockUser(phoneNumber);
            return Ok();
        }


        [Authorize(Roles = "Admin")]
        [HttpPost("PersonalRegistration")]
        public async Task<IActionResult> PersonalRegistion(PersonalRegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                var branch = _branchService.GetBranchById(model.BranchId);
                var role = await _roleManager.FindByIdAsync(model.RoleId);
                User user = new User()
                {
                    UserName = model.PhoneNumber,
                    PhoneNumber = model.PhoneNumber,
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    ImgURL = model.ImgURL,
                    Branch = branch
                };

                var result = await _userManager.CreateAsync(user, model.Password);


                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, role.Name);
                    return Ok(new { Status = "Success", Message = "User created successfully!" });
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }

            return Ok(new { Status = "Success", Message = "User created successfully!" });
        }


        [Authorize(Roles = "Admin")]
        [HttpPut("UnblockUser")]
        public IActionResult Unblock(string phoneNumber)
        {
            _adminServices.UnblockUser(phoneNumber);
            return Ok();

        }


        [Authorize]
        [HttpPut("DeleteUser")]
        public IActionResult DeleteUser(string phoneNumber)
        {
            _adminServices.DeleteUser(phoneNumber);
            return Ok();
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("GetActiveUsers")]
        public async Task<IActionResult> GetActiveUsers()
        {
            var AllActiveusers = _adminServices.GetActiveUsers();
            List<UserModel> mappedUserModel = new List<UserModel>();
            List<User> activeusers = new List<User>();
            if (AllActiveusers.Count != 0)
            {
                foreach (var user in AllActiveusers)
                {
                    var isInRole = await _userManager.IsInRoleAsync(user, "user");
                    if (isInRole== true )
                    {
                        activeusers.Add(user);
                    }
                }

                mappedUserModel = _mapper.Map<List<UserModel>>(activeusers);
                return Ok(mappedUserModel);
            }

            return NoContent();
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("GetBlockedUsers")]
        public IActionResult GetBlockedUsers()
        {
            var blockedUSers = _adminServices.GetBlockedUsers();

            if (blockedUSers.Count != 0)
            {
                var mapedusers = _mapper.Map<List<UserModel>>(blockedUSers);
                return Ok(mapedusers);
            }

            return NoContent(); 
        }
    }
}
