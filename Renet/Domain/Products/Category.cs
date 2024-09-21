using Domain.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products
{
    public class Category
    {
        private Category() { }
        public Category(string name, string icon, string image)
        {
            if (string.IsNullOrEmpty(name))
                throw new ApplicationException(ErrorMessage.InvalidCategoryName);

            if (string.IsNullOrEmpty(icon))
                throw new ApplicationException(ErrorMessage.InvalidCategoryIconOrImage);

            if (string.IsNullOrEmpty(image))
                throw new ApplicationException(ErrorMessage.InvalidCategoryIconOrImage);

            Name = name.Trim();
            Icon = icon.Trim();
            Image = image.Trim();
        }
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Icon { get; private set; }
        public string Image { get; private set; }

        public void Update(string name, string icon, string image)
        {
            if (string.IsNullOrEmpty(name))
                throw new ApplicationException(ErrorMessage.InvalidCategoryName);

            if (string.IsNullOrEmpty(icon))
                throw new ApplicationException(ErrorMessage.InvalidCategoryIconOrImage);

            if (string.IsNullOrEmpty(image))
                throw new ApplicationException(ErrorMessage.InvalidCategoryIconOrImage);

            Name = name.Trim();
            Icon = icon.Trim();
            Image = image.Trim();
        }
    }
}
