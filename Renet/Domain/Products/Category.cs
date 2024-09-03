using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products
{
    public class Category
    {
        public Category(string name , string icon , string image)
        {
            Name = name;
            Icon = icon;
            Image = image;
        }
        public Guid Id { get; set; }
        public string Name { get;private set; }
        public string Icon { get;private set; }
        public string Image { get;private set; }
    }
}
