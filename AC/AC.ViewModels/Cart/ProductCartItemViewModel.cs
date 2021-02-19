namespace AC.ViewModels.Cart
{
    public class ProductCartItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Size { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}