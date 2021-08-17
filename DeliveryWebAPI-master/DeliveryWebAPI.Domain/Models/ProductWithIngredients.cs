using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryWebAPI.Domain.Models
{
    public class ProductWithIngredients
    {
        public int Id { get; set; }

        public Product product { get; set; }

        public Ingredient ingredient { get; set; }
    }
}
