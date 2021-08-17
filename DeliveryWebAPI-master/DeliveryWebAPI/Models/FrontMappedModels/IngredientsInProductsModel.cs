using DeliveryWebAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryWebAPI.Models.FrontMappedModels
{
    public class IngredientsInProductsModel
    {
        public int productId { get; set; }

        public int ingredientId { get; set; }
    }
}
