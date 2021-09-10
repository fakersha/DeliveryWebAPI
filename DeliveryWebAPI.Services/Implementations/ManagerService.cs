using DeliveryWebAPI.Domain;
using DeliveryWebAPI.Domain.Models;
using DeliveryWebAPI.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace DeliveryWebAPI.Services.Implementations
{
    public class ManagerService : IManagerService
    {
        readonly private ApplicationDbContext _context;

        public ManagerService(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddIngredient(Ingredient ingredient)
        {
            await _context.Ingredients.AddAsync(ingredient);
            var Result = await _context.SaveChangesAsync();
            if (Result > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> AddIngredientsInProduct(ProductWithIngredients productWithIngredients)
        {
            await _context.ProductsWithIngredients.AddAsync(productWithIngredients);
            var Result = await _context.SaveChangesAsync();
            if (Result > 0 )
            {
                return true;

            }
            return false;
        }

        public async Task<bool> AddProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            var Result = await _context.SaveChangesAsync();
            if (Result > 0)
            {
                return true;
            }
            return false;
        }

        public Ingredient FindIngredientById(int Id)
        {
            Ingredient ingredient = _context.Ingredients.FirstOrDefault(i => i.Id == Id);
            return ingredient;
        }

        public Product FindProductById(int Id)
        {
            Product product = _context.Products.FirstOrDefault(i => i.id == Id);
            return product;
        }
    }
}
