using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Products {
    public class ProductVariantDto {
        public Guid Id { get;  set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
    }

    public class VariantDto {
        public Guid Id { get; set; }
       
        public string Color { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
