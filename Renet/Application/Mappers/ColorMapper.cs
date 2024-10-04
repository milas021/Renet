using Application.Dtos.Products;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public static class ColorMapper
    {
        public static ColorDto ToDto(this Color color)
        {
            var dto = new ColorDto()
            {
                HexCode = color.HexCode,
                Id = color.Id,
                Name = color.Name,
            };

            return dto;
        }
    }
}
