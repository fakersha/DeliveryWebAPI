using DeliveryWebAPI.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryWebAPI.Infrastructure
{
    public class CustomUserValidator : UserValidator<User>
    {
        public override async Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
        {
            IdentityResult result = await base.ValidateAsync(manager, user);

            List<IdentityError> errors = result.Succeeded ? new List<IdentityError>() : result.Errors.ToList();

            if (user.PhoneNumber.Length != 9)
            {
                errors.Add(new IdentityError
                {
                    Code = "InvaildPhoneNumber",
                    Description = "This phone number not exist!"
                });
            }
            return errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());

        }
    }
}
