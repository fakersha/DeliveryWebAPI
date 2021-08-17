using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryWebAPI.Domain.Models
{
    public class Product
    {
        public int id { get; set; }

        public string Name { get; set; }

        public Category category { get; set; }

        public decimal Price { get; set; }

       

    }
}
