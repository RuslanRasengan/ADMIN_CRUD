using Microsoft.AspNetCore.Mvc;
using AC.Interfaces.BusinessLogic.Services;
using System.Threading.Tasks;

namespace AC.WEB.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartService _cartService;

        public CartViewComponent(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cartDetails = await _cartService.GetCartDetailsAsync(HttpContext.Session);
            return View("Default", cartDetails);
        }
    }
}
