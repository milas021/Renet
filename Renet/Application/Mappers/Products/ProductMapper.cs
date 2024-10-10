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
                Image = product.Images == null || product.Images.Count() == 0 ? null : product.Images.Where(x => x.IsMainPicture).FirstOrDefault().Name,
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
                Category = product.Category.Name ,
                MainImage = product.Images == null || product.Images.Count() == 0 ? null : product.Images.Where(x=> x.IsMainPicture).SingleOrDefault().Name ,

            };
            return dto;
        }
    }
}
