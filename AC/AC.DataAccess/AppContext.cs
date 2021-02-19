using Microsoft.EntityFrameworkCore;
using AC.Entities;
using AC.Entities.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AC.DataAccess
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options) { }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderItem>(oi =>
            {
                oi.Property(u => u.SizesCount)
                    .HasConversion(
                        v => JsonConvert.SerializeObject(v, Formatting.None),
                        v => JsonConvert.DeserializeObject<Dictionary<string, int>>(v)
                    );
            });

            modelBuilder.Entity<Product>(p =>
            {
                p.Property(i => i.Type)
                    .HasConversion<string>();
                //p.Property(i => i.Type)
                //    .HasConversion(
                //        v => v.ToString(),
                //        v => (ProductType)Enum.Parse(typeof(ProductType), v));
            });
        }
    }
}