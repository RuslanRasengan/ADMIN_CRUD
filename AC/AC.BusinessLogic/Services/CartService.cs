using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using AC.Interfaces.BusinessLogic.Services;
using AC.Interfaces.DataAccess.Repositories;
using AC.ViewModels.Cart;
using AC.ViewModels.DTO;
using AC.ViewModels.Session;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace AC.BusinessLogic.Services
{
    public class CartService : ICartService
    {
        private readonly IProductRepository _productRepository;

        private const string SessionKey = "CartProducts";

        public CartService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductCartViewModel> GetCartDetailsAsync(ISession session)
        {
            var sessionData = this.GetSessionCartData(session);

            var result = new ProductCartViewModel();

            if (!sessionData.Products.Any())
            {
                return result;
            }

            var ids = sessionData.Products.Select(x => x.Id);

            var products = await _productRepository.GetAll()
                .Where(x => ids.Contains(x.Id))
                .Select(x => new ProductForCartDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Image = x.Images.FirstOrDefault().Name
                }).ToListAsync();

            result.Products = sessionData.Products
                .Select(x => new ProductCartItemViewModel
                {
                    Id = x.Id,
                    Name = products.FirstOrDefault(p => p.Id == x.Id).Name,
                    Image = products.FirstOrDefault(p => p.Id == x.Id).Image,
                    Price = products.FirstOrDefault(p => p.Id == x.Id).Price * x.Count,
                    Count = x.Count,
                    Size = x.Size
                }).ToList();

            return result;
        }

        public void AddProductToCart(ISession session, AddProductToCartViewModel addProductToCart)
        {
            var sessionData = this.GetSessionCartData(session);

            var existProduct = sessionData.Products.FirstOrDefault(x => x.Id == addProductToCart.Id && x.Size == addProductToCart.Size);

            if (existProduct != default)
            {
                existProduct.Count++;
            }
            else
            {
                sessionData.Products.Add(new CartDetailsItemSessionViewModel
                {
                    Id = addProductToCart.Id,
                    Size = addProductToCart.Size,
                    Count = 1
                });
            }

            this.SaveSessionCartData(session, sessionData);
        }

        private CartDetailsSessionViewModel GetSessionCartData(ISession session)
        {
            var sessionDataString = session.GetString(SessionKey);

            CartDetailsSessionViewModel sessionData;

            if (sessionDataString == default)
            {
                sessionData = new CartDetailsSessionViewModel();
            }
            else
            {
                sessionData = JsonConvert.DeserializeObject<CartDetailsSessionViewModel>(sessionDataString);
            }

            return sessionData;
        }

        private void SaveSessionCartData(ISession session, CartDetailsSessionViewModel data)
            => session.SetString(SessionKey, JsonConvert.SerializeObject(data));
    }
}
