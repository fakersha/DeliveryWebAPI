using DeliveryWebAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryWebAPI.Models.FrontMappedModels
{
    public class ProductModel
    {
        public string Name { get; set; }

        public int categoryId { get; set; }

        public decimal Price { get; set; }
    }
}
