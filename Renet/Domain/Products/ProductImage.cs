using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products
{
    public class ProductImage
    {
        public ProductImage()
        {
            
        }
        public ProductImage(string name , bool isMain=false)
        {
            Id = Guid.NewGuid();
            Name = name;
            IsMainPicture = isMain;
        }
        public Guid Id { get;private set; }
        public string Name { get;private set; }
        public bool IsMainPicture { get;private set; }
        public Guid ProductId { get; set; }
    }
}
