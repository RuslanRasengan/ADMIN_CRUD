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
                this.CreateProduct(),

                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
                this.CreateProduct(),
            };

            _productRepository.AddRangeAsync(products).GetAwaiter().GetResult();
        }

        private Product CreateProduct()
        {
            var image = new Image
            {
                Name = "product-123-123-123.jpg",
            };
            return new Product
            {
                Name = "Толстовка 350 V2 Black",
                Price = 11999,
                OldPrice = 5000,
                Images = new List<Image> { image}
            };
        }
    }
}
