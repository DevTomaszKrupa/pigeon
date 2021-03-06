﻿namespace Pigeon.PandaSystem.Models
{
    public class ProductDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public long Count { get; set; }
    }
}
