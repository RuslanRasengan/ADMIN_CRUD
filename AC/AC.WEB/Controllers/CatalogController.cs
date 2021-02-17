using Microsoft.AspNetCore.Mvc;
using AC.Interfaces.BusinessLogic.Services;
using System.Threading.Tasks;

namespace AC.WEB.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductService _productService;
        
        public CatalogController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{controller}")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var products = await _productService.GetProductsForCatalogAsync(page);
            return View(products);
        }

        [HttpGet("{controller}/{id?}")]
        public IActionResult Product(int id)
        {
            return View();
        }

    }
}
