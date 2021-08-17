using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryWebAPI.Models.FrontMappedModels
{
    public class StorageProductModel
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string MeasurementType { get; set; }

        public double Quantity { get; set; }

        public int BranchId { get; set; }

    }
}
