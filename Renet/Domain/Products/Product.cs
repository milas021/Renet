using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products
{
    public class Product
    {
        public Product()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }

        public string Guaranty { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }

        public Category Category { get; set; }
        public IEnumerable<ProductVariant> Variants { get; set; }
        public IEnumerable<Article> Articles { get; set; }
        public IEnumerable<ProductImage> Images { get; set; }
        public IEnumerable<Feature> Features { get; set; }


        public decimal GetMinPrice()
        {
            var min = Variants.Min(x => x.Price);
            return min;
        }

        public decimal GetMaxPrice()
        {
            var max = Variants.Max(x => x.Price);
            return max;
        }

        public bool AnySmallerPrice(decimal price)
        {
            return Variants.Any(x => x.Price < price);
        }

        public bool AnyBiggerPrice(decimal price)
        {
            return Variants.Any(x => x.Price > price);
        }
    }





   
}
