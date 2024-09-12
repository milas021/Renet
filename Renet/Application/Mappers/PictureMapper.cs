using Application.Dtos;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public static class PictureMapper
    {
        public static ProductPictureDto ToDto(this ProductImage picture)
        {
            var dto = new ProductPictureDto()
            {
                Id = picture.Id,
                IsMainPicture = picture.IsMainPicture,
                Name = picture.Name,    
            };

            return dto;
        }
    }
}
