using Demo.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            Product product1 = new()
            {
                Id = 1,
                Title = "Kablosuz Kulaklık",
                Description = "Bluetooth 5.0 destekli, gürültü engelleyici kulaklık.",
                Discount = 10, 
                Price = 700,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            };

            Product product2 = new()
            {
                Id = 2,
                Title = "Mekanik Klavye",
                Description = "RGB aydınlatmalı, mavi switch mekanik klavye.",
                Discount = 5, 
                Price = 30000,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            };

            Product product3 = new()
            {
                Id = 3,
                Title = "Akıllı Saat",
                Description = "Kalp ritmi ölçer, uyku takibi ve GPS destekli akıllı saat.",
                Discount = 15, 
                Price = 50000,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            };
            builder.HasData(product1, product2, product3);
        }
    }
}
