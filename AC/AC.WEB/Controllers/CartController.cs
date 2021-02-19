using Microsoft.AspNetCore.Mvc;
using AC.Interfaces.BusinessLogic.Services;
using AC.ViewModels.Cart;
using System.Threading.Tasks;

namespace AC.WEB.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cartDetails = await _cartService.GetCartDetailsAsync(HttpContext.Session);
            return View(cartDetails);
        }

        [HttpPost]
        public IActionResult AddToCart([FromBody] AddProductToCartViewModel addProductToCart)
        {
            _cartService.AddProductToCart(HttpContext.Session, addProductToCart);
            return ViewComponent("Cart");
        }
    }
}
