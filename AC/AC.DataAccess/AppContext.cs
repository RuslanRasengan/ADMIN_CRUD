using Microsoft.EntityFrameworkCore;
using AC.Entities;

namespace AC.DataAccess
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options) { }


        public virtual DbSet<Product> Products { get; set; }

    }
}
