using AC.ViewModels;
using AC.ViewModels.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AC.Interfaces.BusinessLogic.Services
{
    public interface IProductService 
    {
        Task<IEnumerable<ProductCardViewModel>> GetProductsForMainPageAsync();
        Task<PagedResult<ProductCardViewModel>> GetProductsForCatalogAsync(int page = 1);
        Task<ProductDetailsViewModel> GetProductDetailsByIdAsync(int id);
    }
}
