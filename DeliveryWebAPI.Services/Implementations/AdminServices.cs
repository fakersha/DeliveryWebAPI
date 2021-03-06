using DeliveryWebAPI.Domain;
using DeliveryWebAPI.Domain.Models;
using DeliveryWebAPI.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DeliveryWebAPI.Services.Implementations
{
    public class AdminServices : IAdminServices
    {
        readonly private ApplicationDbContext _context;
        public AdminServices(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCategory(Category category)
        {
            if (category != null)
            {
                _context.Add(category);

                var Result = await _context.SaveChangesAsync();

                if (Result > 0)
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        public async Task<bool> BlockUser(string phoneNumber)
        {
            var blockedUser = _context.Users.FirstOrDefault(user => user.PhoneNumber == phoneNumber);

            if (blockedUser != null)
            {
                blockedUser.IsBlocked = true;

                _context.Update(blockedUser);

                var Result = await _context.SaveChangesAsync();

                if (Result>0)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public async Task<bool> DeleteUser(string phoneNumber)
        {
            var DeletionUser = _context.Users.FirstOrDefault(user => user.PhoneNumber == phoneNumber);

            if (DeletionUser != null)
            {
                DeletionUser.IsDeleted = true;

                _context.Update(DeletionUser);

                var Result = await _context.SaveChangesAsync();

                if (Result > 0)
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        public List<User> GetActiveUsers()
        {
            var AllActiveUsers = _context.Users.Where(user => user.IsBlocked == false && user.IsDeleted == false).ToList();

            return AllActiveUsers;
        }

        public List<User> GetBlockedUsers()
        {
            var BlockedUsers = _context.Users.Where(user => user.IsBlocked == true).ToList();

            return BlockedUsers;

        }

        public Category GetCategoryById(int Id)
        {
            var category = _context.Categories.FirstOrDefault(p => p.Id == Id);
            return category;
        }

        public User GetUserByNumber(string number)
        {
            var SearchedUser = _context.Users.FirstOrDefault(user => user.PhoneNumber == number);

            if (SearchedUser != null)
            {
                return SearchedUser;
            }

            return null;
        }

        public async Task<bool> RemoveCategoryById(int Id)
        {
            var Category = _context.Categories.FirstOrDefault(o => o.Id == Id);
            if (Category != null)
            {
                _context.Categories.Remove(Category);
                var result = await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> UnblockUser(string phoneNumber)
        {
            var unblockUser = _context.Users.FirstOrDefault(user => user.PhoneNumber == phoneNumber);
            if (unblockUser != null)
            {
                unblockUser.IsBlocked = false;
                _context.Update(unblockUser);
                var Result = await _context.SaveChangesAsync();
                if (Result > 0)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public async Task<bool> UpdateCategory(Category category)
        {
            if (category != null)
            {
                _context.Categories.Update(category);
               
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

      
    }
}
