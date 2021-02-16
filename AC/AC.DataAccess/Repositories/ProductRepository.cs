using AC.Interfaces.DataAccess.Repositories;
using AC.Entities;

namespace AC.DataAccess.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(AppContext context) : base(context) { }
    }
}
