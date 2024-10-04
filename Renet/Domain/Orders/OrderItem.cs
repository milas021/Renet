using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders
{
    public class OrderItem
    {
        public Guid Id { get;private set; }
        public Guid OrderId { get; private set; } 
        public Guid ProductId { get; private set; }
        public ProductVariant Variant { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        public Order Order { get; private set; } 
    }
}
