using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryWebAPI.Domain.Models
{
    public class StorageProduct
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string MeasurementType { get; set; }

        public double Quantity { get; set; }

        public Branch Branch { get; set; }
    }

}
