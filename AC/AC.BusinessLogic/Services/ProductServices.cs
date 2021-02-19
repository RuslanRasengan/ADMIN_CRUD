using Microsoft.EntityFrameworkCore;
using AC.Common.Extensions;
using AC.Interfaces.BusinessLogic.Services;
using AC.Interfaces.DataAccess.Repositories;
using AC.Entities;
using AC.Entities.Enums;
using AC.ViewModels;
using AC.ViewModels.Product;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AC.BusinessLogic.Services
{
    public class ProductServices : IProductService
    {
        private readonly IProductRepository _productRepository;

        private const int PageSize = 16;

        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            //this.Seed();
        }

        public async Task<IEnumerable<ProductCardViewModel>> GetProductsForMainPageAsync()
        {
            var products = await _productRepository.GetAll()
                .Where(x => x.OnMainPage)
                .OrderBy(x => x.Order)
                .Select(x => new ProductCardViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    OldPrice = x.OldPrice,
                    Price = x.Price,
                    Type = x.Type,
                    Image = x.Images.FirstOrDefault().Name
                })
                .ToListAsync();
            return products;
        }

        public async Task<PagedResult<ProductCardViewModel>> GetProductsForCatalogAsync(int page = 1)
        {
            var products = await _productRepository
               .GetAll()
               .Select(x => new ProductCardViewModel
               {
                   Id = x.Id,
                   Name = x.Name,
                   OldPrice = x.OldPrice,
                   Price = x.Price,
                   Type = x.Type,
                   Image = x.Images.FirstOrDefault().Name
               })
               .GetPaged(page, PageSize);

            return products;
        }

        public async Task<ProductDetailsViewModel> GetProductDetailsByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            var productView = new ProductDetailsViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                OldPrice = product.OldPrice,
                Price = product.Price,
                VendorCode = product.VendorCode,
                Images = product.Images.OrderBy(x => x.Order).Select(x => x.Name).ToList()
            };
            return productView;
        }

        private void Seed()
        {
            var products = new List<Product>
            {
                this.CreateProduct(true),//1
                this.CreateProduct(true),
                this.CreateProduct(true),
                this.CreateProduct(true),
                this.CreateProduct(true),
                this.CreateProduct(true),
                this.CreateProduct(true),
                this.CreateProduct(true),//8
                this.CreateProduct(false),//1
                this.CreateProduct(false),
                this.CreateProduct(false),
                this.CreateProduct(false),
                this.CreateProduct(false),
                this.CreateProduct(false),
                this.CreateProduct(false),
                this.CreateProduct(false),//8

            };

            _productRepository.AddRangeAsync(products).GetAwaiter().GetResult();
        }

        private Product CreateProduct(bool isMain)
        {
            var image = new Image
            {
                Name = "product-123-123-123.jpg",
                Order = 0
            };

            return new Product
            {
                Name = "Черная толстовка 350 V2 Black (Тип толстовка)",
                OldPrice = 25999M,
                Price = 11999M,
                Description = "Sime descr",
                OnMainPage = isMain,
                Images = new List<Image> { image },
                Type = Entities.Enums.ProductType.Hoodie,
                VendorCode = "Vendor code"
            };
        }
    }
}
