using System.Collections.Generic;

namespace AC.ViewModels.Product
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public string VendorCode { get; set; }
        public List<string> Images { get; set; }
    }
}
