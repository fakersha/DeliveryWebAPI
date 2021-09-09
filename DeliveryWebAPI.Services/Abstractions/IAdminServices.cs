using DeliveryWebAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryWebAPI.Services.Abstractions
{
    public interface IAdminServices
    {
        User GetUserByNumber(string number);

        List<User> GetBlockedUsers();

        List<User> GetActiveUsers();

        Task<bool> DeleteUser(string phoneNumber);

        Task<bool> UnblockUser(string phoneNumber);

        Task<bool> BlockUser(string phoneNumber);

        Task<bool> AddCategory(Category category);

        Task<bool> RemoveCategoryById(int Id);

        Task<bool> UpdateCategory(Category category);

        Category GetCategoryById(int Id);
    }
}
