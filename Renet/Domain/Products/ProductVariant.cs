using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products
{
    public class ProductVariant
    {
        public ProductVariant(decimal price , int stock)
        {
            Id = Guid.NewGuid();
            Price = price;
            Stock = stock;

        }
        public Guid Id { get;private set; }
        public Product Product { get; set; }
        public Color Color { get; set; }
        public decimal  Price { get; set; }
        public int Stock { get; set; }
    }
}
