using Application.Dtos.Products;
using Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Orders {
    public class OrderItemDto {
        public Guid Id { get;  set; }
        public ProductVariantDto Product { get;  set; }
        public int Quantity { get;  set; }
        public decimal Price { get;  set; }

        
    }
}
