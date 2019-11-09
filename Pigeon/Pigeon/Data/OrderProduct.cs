namespace Pigeon.Data
{
    public class OrderProduct
    {
        public long OrderProductId { get; set; }

        public long ProductId { get; set; }
        public virtual Product Product { get; set; }
        public long OrderId { get; set; }
        public virtual Order Order { get; set; }   
    }
}