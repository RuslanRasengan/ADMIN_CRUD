using Microsoft.AspNetCore.Http;
using AC.ViewModels.Cart;
using System.Threading.Tasks;

namespace AC.Interfaces.BusinessLogic.Services
{
    public interface ICartService
    {
        Task<ProductCartViewModel> GetCartDetailsAsync(ISession session);
        void AddProductToCart(ISession session, AddProductToCartViewModel addProductToCart);
    }
}
