using AC.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using AC.Interfaces.BusinessLogic.Services;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AC.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProductsForMainPageAsync();
            return View(products);
        }

        public IActionResult Catalog()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Guarantee()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}
