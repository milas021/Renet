using Application.Dtos;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers.Products
{
    public static class ProductMapper
    {
        public static SimpleProductDto ToSimpleDto(this Product product)
        {
            var x = product.Images.Count();
            var dto = new SimpleProductDto()
            {

                Id = product.Id,
                Name = product.Name,
                Price = product.GetMinPrice(),
                Picture = product.Images == null || product.Images.Count() == 0 ? null : product.Images.Where(x => x.IsMainPicture).FirstOrDefault().Name,
            };
            return dto;
        }

        public static ProductDto ToDto(this Product product)
        {
            var dto = new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                //Price = product.Price,
                Description = product.Description,
                EnglishName = product.EnglishName,
                Guaranty = product.Guaranty,

                Articles = product.Articles.Select(x => x.ToDto()).ToList(),
                Category = product.Category.ToDto(),
                Features = product.Features.Select(x => x.ToDto()).ToList(),
                PictureDtos = product.Images.Select(x => x.ToDto()).ToList()
            };
            return dto;
        }
    }
}
