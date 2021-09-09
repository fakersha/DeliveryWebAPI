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
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddProduct(Product product)
        {
            try
            {
               await _context.Products.AddAsync(product);
               await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new ArgumentException();
            }
        }

        public Product GetProductById(int Id)
        {
            try
            {
                return _context.Products.SingleOrDefault(product => product.id == Id);
            }
            catch (Exception)
            {
                throw new ArgumentNullException("Product not found!");
            }
            
        }

        public IQueryable<Product> GetProducts()
        {
            try
            {
                return _context.Products;
            }
            catch (Exception)
            {
                throw new ArgumentNullException("Products not found!");
            }
        }
    }
}

