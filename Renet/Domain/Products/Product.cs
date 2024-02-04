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
        public Guid Id { get;private set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public double Price { get; set; }
        public string Guaranty { get; set; }
        public string Description { get; set; }
        public Brand Brand { get; set; }
        public Color Color { get; set; }
        public Category Category { get; set; }
        public IEnumerable<Article> Articles { get; set; }
        public IEnumerable<ProductPicture> Pictures { get; set; }
        public IEnumerable<Feature> Features { get; set; }

    }

    public enum Color
    {
        Red,
        Green,
        Blue,
        Yellow,

    }

    public enum Brand
    {
        Apple ,
        Samsung ,
        Xiaomi ,
        Huawei
    }
}
