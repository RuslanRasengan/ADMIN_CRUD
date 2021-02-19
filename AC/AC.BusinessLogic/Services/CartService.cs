using AC.Interfaces.BusinessLogic.Services;
using Microsoft.AspNetCore.Http;
using AC.ViewModels.Cart;

namespace AC.BusinessLogic.Services
{
    public class CartService : ICartService
    {
        private const string SessionKey = "CartProducts";

        public void AddProductToCart(ISession session, AddProductToCart addProductToCart)
        {
        }
    }
}
