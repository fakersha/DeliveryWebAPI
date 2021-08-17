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

        public void AddIngredient(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
            _context.SaveChanges();
        }

        public void AddIngredientsInProduct(ProductWithIngredients productWithIngredients)
        {
            _context.productsWithIngredients.Add(productWithIngredients);
            _context.SaveChanges();
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
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
