using AC.ViewModels.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AC.Interfaces.BusinessLogic.Services
{
    public interface IProductService 
    {
        Task<IEnumerable<ProductCardViewModel>> GetProductsForMainPageAsync();
    }
}
