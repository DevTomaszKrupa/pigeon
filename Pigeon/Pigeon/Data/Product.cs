using System.Collections.Generic;

namespace Pigeon.Data
{
    public class Product
    {
        public Product()
        {
            OrderProducts = new HashSet<OrderProduct>();
            ShoppingCardProducts = new HashSet<ShoppingCardProduct>();
        }

        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Barcode { get; set; }
        public long Count { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
        public virtual ICollection<ShoppingCardProduct> ShoppingCardProducts { get; set; }
    }
}
