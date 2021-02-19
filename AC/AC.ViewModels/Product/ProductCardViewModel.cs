using AC.Entities.Enums;

namespace AC.ViewModels.Product
{
    public class ProductCardViewModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal OldPrice { get; set; }
        public decimal Price { get; set; }
        public ProductType Type { get; set; }
        public string Image { get; set; }
    }
}
