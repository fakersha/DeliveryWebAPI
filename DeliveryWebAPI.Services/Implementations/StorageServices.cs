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





        public async Task AddProduct(StorageProduct product)
        {
            await _context.Storage.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int productId)
        {
            var DeletedProduct = _context.Storage.FirstOrDefault(product => product.Id == productId);

            _context.Storage.Remove(DeletedProduct);
            var result = await _context.SaveChangesAsync();
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
