using DeliveryWebAPI.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryWebAPI.Domain
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            :base(options)
        {

        }

        public DbSet<StorageProduct> Storage { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<OrderStatus> OrderStatuses { get; set; }

        public DbSet<Branch> Branches { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Personal> Personals { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductWithIngredients> ProductsWithIngredients { get; set; }
    }
}
