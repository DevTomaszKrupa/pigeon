using System.Collections.Generic;

namespace Pigeon.PandaSystem.Models
{
    public class BulkUpdateRequest
    {
        public string ShopUniqueCode { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
