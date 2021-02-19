using System.Collections.Generic;
using System.Linq;

namespace AC.ViewModels.Cart
{
    public class ProductCartViewModel
    {
        public List<ProductCartItemViewModel> Products { get; set; }
        public decimal Price => Products.Sum(x => x.Price);
        public int Count => Products.Sum(x => x.Count);

        public ProductCartViewModel()
        {
            Products = new List<ProductCartItemViewModel>();
        }
    }
}
