using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Products {
    public class ProductDto {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public string Guaranty { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public CategoryDto Category { get; set; }
        public IEnumerable<VariantDto> Varians { get; set; }
        public IEnumerable<ArticleDto> Articles { get; set; }
        public IEnumerable<ProductPictureDto> Images { get; set; }
        public IEnumerable<FeatureDto> Features { get; set; }

    }
}
