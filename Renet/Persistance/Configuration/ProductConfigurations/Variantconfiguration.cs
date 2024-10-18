using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Configuration.ProductConfigurations;
public class Variantconfiguration : IEntityTypeConfiguration<Variant> {
    public void Configure(EntityTypeBuilder<Variant> builder) {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.HasOne(x => x.Color)
            .WithOne();
    }
}
