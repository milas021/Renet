using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Configuration.ProductConfigurations;
public class ArticleConfiguration : IEntityTypeConfiguration<Article> {
    public void Configure(EntityTypeBuilder<Article> builder) {
       builder.HasKey(x=>x.Id);
    }
}
