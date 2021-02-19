using System.Collections.Generic;

namespace AC.Entities
{
    public class OrderItem : BaseEntity
    {
        public decimal Price { get; set; }
        public Dictionary<string, int> SizesCount { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
