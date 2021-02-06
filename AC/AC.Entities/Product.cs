using AC.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AC.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal OldPrice { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public ProductType Type{ get; set; }
        public string VendorCode { get; set; }
        public bool OnMainPage { get; set; }
    }
}
