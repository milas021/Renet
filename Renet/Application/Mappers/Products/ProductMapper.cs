using Application.Dtos;
using Application.Dtos.Products;
using Domain.Products;

namespace Application.Mappers.Products {
    public static class ProductMapper
    {
        public static SimpleProductAdminDto ToSimpleDto(this Product product)
        {
            var dto = new SimpleProductAdminDto()
            {
                Id = product.Id,
                Name = product.Name,
                Image = product.GetMainImage(),
                Category = product.Category.Name  ,
                Brand = product.Brand,
            };
            return dto;
        }

        public static ProductDto ToDto(this Product product)
        {
            var dto = new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                EnglishName = product.EnglishName,
                Guaranty = product.Guaranty,
                Category = product.Category.ToDto() ,
                Varians = product.Variants.Select(x=>x.ToDto()).ToList(),
                Articles = product.Articles.Select(x=>x.ToDto()) ,
                Brand = product.Brand,
                Features = product.Features.Select(x=>x.ToDto()),
                Images = product.Images.Select(x => x.ToDto())
                
            };
            return dto;
        }

        public static SimpleProductCustomerDto ToSimpleCustomerDto(this Product product) {
            var dto = new SimpleProductCustomerDto() {
                Category = product.Category.Name,
                Name = product.Name,
                Price = product.GetMinPrice(),
                MainImage = product.GetMainImage(),
                HexColor = product.GetHexColors(),
                Brand = product.Brand,
                Id = product.Id,
            };
            return dto;
        }
    }
}
