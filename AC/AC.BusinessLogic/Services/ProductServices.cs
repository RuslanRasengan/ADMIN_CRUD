using AC.Interfaces.Services;
using AC.DataAccess.Interfaces.Repositories;

namespace AC.BusinessLogic.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;

        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
    }
}
