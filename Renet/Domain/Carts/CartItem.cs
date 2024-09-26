using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Carts
{
    public class CartItem
    {
        public Guid Id { get; private set; }
        public Guid CartId { get; private set; } 
        public Guid ProductId { get; private set; }
        public Guid ProductVariantId { get; private set; } 
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        public Cart Cart { get; private set; }
    }
}
