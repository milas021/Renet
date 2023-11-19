using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Configuration.ProductConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id); 
            builder.Property(x=>x.Id).ValueGeneratedNever();

            builder.HasMany(x => x.Articles).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x=>x.Pictures).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x=>x.Features).WithOne().OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Category).WithOne().HasForeignKey<Category>("ProductId");
        }
    }
}
