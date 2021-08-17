using DeliveryWebAPI.Domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryWebAPI
{
    public class SeedData
    {
        public static void SeedRoles(IApplicationBuilder app)
        {
            using (var @scope = app.ApplicationServices.CreateScope())
            {
                try
                {
                    RoleManager<IdentityRole> _roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                    bool AdminRoleIsCreated = false;
                    bool UserRoleIsCreated = false;
                    bool ManagerRoleIsCreated = false;
                    bool CourierRoleIsCreated = false;

                    foreach (var role in _roleManager.Roles)
                    {
                        if (role.Name == "Admin")
                        {
                            AdminRoleIsCreated = true;
                        }
                        else if (role.Name == "User")
                        {
                            UserRoleIsCreated = true;
                        }
                        else if (role.Name == "Manager")
                        {
                            ManagerRoleIsCreated = true;
                        }
                        else if (role.Name == "Courier")
                        {
                            CourierRoleIsCreated = true;
                        }

                    }

                    if (AdminRoleIsCreated == false)
                    {
                        var CreateAdmin = _roleManager.CreateAsync(new IdentityRole() { Name = "Admin" }).Result;
                    }
                    if (UserRoleIsCreated == false)
                    {
                        var CreateUser = _roleManager.CreateAsync(new IdentityRole() { Name = "User" }).Result;
                    }
                    if (ManagerRoleIsCreated == false)
                    {
                        var CreateManager = _roleManager.CreateAsync(new IdentityRole() { Name = "Manager" }).Result;
                    }
                    if (CourierRoleIsCreated == false)
                    {
                        var CreateCourier = _roleManager.CreateAsync(new IdentityRole() { Name = "Courier" }).Result;
                    }
                }

                catch (Exception)
                {

                }
            }
        }

        public static void CreateAdministrator(IApplicationBuilder app)
        {
            using (var @scope = app.ApplicationServices.CreateScope())
            {
                try
                {
                    UserManager<User> _userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

                    bool IsInRole = false;

                    foreach (var user in _userManager.Users)
                    {
                        if (_userManager.IsInRoleAsync(user, "Admin").Result)
                        {
                            IsInRole = true;
                        }
                    }

                    if (IsInRole == false)
                    {
                        User user = new User()
                        {
                            UserName = "Admin",
                            Firstname = "Admin",
                            Lastname = "Admin",
                            Email = "Admin@example.com",
                            PhoneNumber = "598913848",
                            IsBlocked = false
                        };

                        var result = _userManager.CreateAsync(user, "Admin1").Result;

                        if (result.Succeeded)
                        {
                            var AddInRole = _userManager.AddToRoleAsync(user, "Admin").Result;
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
