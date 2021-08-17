using DeliveryWebAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliveryWebAPI.Services.Abstractions
{
    public interface IProductService
    {
        IQueryable<Product> GetProducts();

        Product GetProductById(int Id);

        void AddProduct(Product product);

    }
}
