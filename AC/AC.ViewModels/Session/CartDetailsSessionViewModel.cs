using System.Collections.Generic;

namespace AC.ViewModels.Session
{
    public class CartDetailsSessionViewModel
    {
        public List<CartDetailsItemSessionViewModel> Products { get; set; }

        public CartDetailsSessionViewModel()
        {
            Products = new List<CartDetailsItemSessionViewModel>();
        }
    }
}