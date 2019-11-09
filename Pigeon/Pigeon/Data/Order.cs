using System;
using System.Collections;
using System.Collections.Generic;

namespace Pigeon.Data
{
    public class Order
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public long OrderId { get; set; }
        public DateTime CreatedDate { get; set; }
        
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}