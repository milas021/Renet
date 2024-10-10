using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Products
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Guaranty { get; set; }
        public string MainImage { get; set; }
    }
}
