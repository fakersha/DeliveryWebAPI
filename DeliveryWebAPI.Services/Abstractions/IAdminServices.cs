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

        void DeleteUser(string phoneNumber);

        void UnblockUser(string phoneNumber);

        void BlockUser(string phoneNumber);

        void AddCategory(Category category);

        Task<bool> RemoveCategoryById(int Id);

        Task<bool> UpdateCategory(Category category);

        Category GetCategoryById(int Id);
    }
}
