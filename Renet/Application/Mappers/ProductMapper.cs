using Application.Dtos;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public static class ProductMapper
    {
        public static SimpleProductDto ToSimpleDto(this Product product)
        {
            var x = product.Pictures.Count();
            var dto = new SimpleProductDto()
            {
                
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Picture = (product.Pictures == null || product.Pictures.Count()== 0 ) ?null :product.Pictures.Where(x=>x.IsMainPicture).FirstOrDefault().Name ,
            };
            return dto;
        }

        public static ProductDto ToDto(this Product product)
        {
            var dto = new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                EnglishName = product.EnglishName,
                Guaranty = product.Guaranty,
                
                Articles = product.Articles.Select(x=>x.ToDto()).ToList(),
                Category = product.Category.ToDto(),
                Features = product.Features.Select(x=>x.ToDto()).ToList(),
                PictureDtos = product.Pictures.Select(x=>x.ToDto()).ToList()
            };
            return dto;
        }
    }
}
