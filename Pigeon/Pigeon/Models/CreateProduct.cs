namespace Pigeon.Models
{
    public class CreateProduct
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Barcode { get; set; }
        public long Count { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}