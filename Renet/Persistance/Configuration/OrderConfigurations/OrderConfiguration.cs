using Domain.Orders;
using Domain.Payments;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Configuration.OrderConfigurations;
public class OrderConfiguration : IEntityTypeConfiguration<Order> {
    public void Configure(EntityTypeBuilder<Order> builder) {

        builder.HasKey(x => x.Id);
        builder.Property(x=>x.Id).ValueGeneratedNever();

        builder.HasOne(x => x.User)
            .WithMany();
            //.HasForeignKey(x => x.UserId);

        builder.HasMany(x => x.OrderItems)
            .WithOne(x => x.Order);

        builder.HasOne(x => x.Payment)
            .WithOne(x => x.Order)
            .HasForeignKey<Payment>(x => x.OrderId);



    }
}

