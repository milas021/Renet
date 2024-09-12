using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class ProductDto
    {
        //todo : تغییر ساختار دی تی او با  توجه به jk,u lpw,g 
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Guaranty { get; set; }
        public CategoryDto  Category { get; set; }
        public List<ArticleDto> Articles { get; set; }
        public List<ProductPictureDto> PictureDtos { get; set; }
        public List<FeatureDto> Features { get; set; }

    }
}
