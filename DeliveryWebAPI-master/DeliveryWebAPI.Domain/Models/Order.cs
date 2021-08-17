using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryWebAPI.Domain.Models
{
   public class Order
    {
        public int Id { get; set; }

        public int OrderID { get; set; }

        public decimal OrderPrice { get; set; }

        public OrderStatus Status { get; set; }

        public Branch Branch { get; set; }
     
        public User User { get; set; }

        public User Personal { get; set; }

        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
