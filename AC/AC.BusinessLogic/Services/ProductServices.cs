using Microsoft.EntityFrameworkCore;
using AC.Interfaces.BusinessLogic.Services;
using AC.Interfaces.DataAccess.Repositories;
using AC.Entities;
using AC.ViewModels.Product;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AC.BusinessLogic.Services
{
    public class ProductServices : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            this.Seed();
        }

        public async Task<IEnumerable<ProductCardViewModel>> GetProductsForMainPageAsync()
        {
            var products = await _productRepository
               .GetAll()
               .Select(x => new ProductCardViewModel
               {
                   Name = x.Name,
                   Price = x.Price,
                   Image = x.Images.FirstOrDefault().Name
               }).ToListAsync();

            return products;
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
                Images = new List<Image> { image}
            };
        }
    }
}
