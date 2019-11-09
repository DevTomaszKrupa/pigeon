using System.Collections.Generic;

namespace Pigeon.Data
{
    public class ShoppingCard
    {
        public ShoppingCard()
        {
            ShoppingCardProducts = new HashSet<ShoppingCardProduct>();
        }

        public long ShoppingCardId { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<ShoppingCardProduct> ShoppingCardProducts { get; set; }
    }
}