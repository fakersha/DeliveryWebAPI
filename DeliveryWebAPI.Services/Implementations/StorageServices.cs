using DeliveryWebAPI.Domain;
using DeliveryWebAPI.Domain.Models;
using DeliveryWebAPI.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryWebAPI.Services.Implementations
{
    public class StorageServices : IStorageServices
    {
        private readonly ApplicationDbContext _context; 
        public StorageServices(ApplicationDbContext context)
        {
            _context = context;
        }





        public async Task<bool> AddProduct(StorageProduct product)
        {
            await _context.Storage.AddAsync(product);

            var Result =  await _context.SaveChangesAsync();

            if (Result > 0 )
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            var DeletedProduct = _context.Storage.FirstOrDefault(product => product.Id == productId);

            _context.Storage.Remove(DeletedProduct);

            var Result = await _context.SaveChangesAsync();
            if (Result > 0)
            {
                return true;
            }

            return false;

        }

        public IQueryable<StorageProduct> GetBranchStorageProducts(int branchId)
        {
            var SearchedProducts = _context.Storage.Where(product => product.Branch.Id == branchId);

            return SearchedProducts;
        }

        public IQueryable<StorageProduct> GetMainStorageProducts()
        {
            var SearchedProducts = _context.Storage.Where(product => product.Branch.Id == 0);

            return SearchedProducts;
        }
    }
}
