using System.Collections.Generic;

namespace AC.Entities
{
    public class Order : BaseEntity
    {
        public decimal Price { get; set; }
        public virtual IEnumerable<OrderItem> OrderItem { get; set; }
    }
}
