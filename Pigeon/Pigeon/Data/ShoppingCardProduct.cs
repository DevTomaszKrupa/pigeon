namespace Pigeon.Data
{
    public class ShoppingCardProduct
    {
        public long ShoppingCardProductId { get; set; }

        public int Count { get; set; }

        public long ProductId { get; set; }
        public Product Product { get; set; }

        public long ShoppingCardId { get; set; }
        public ShoppingCard ShoppingCard { get; set; }
    }
}