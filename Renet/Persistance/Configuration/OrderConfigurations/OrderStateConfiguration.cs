using Domain.Orders.OrderSates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Configuration.OrderConfigurations {
    public class OrderStateConfiguration : IEntityTypeConfiguration<OrderStateBase> {
        public void Configure(EntityTypeBuilder<OrderStateBase> builder) {
            builder.HasKey(t => t.Id);

           
        }
    }
}
