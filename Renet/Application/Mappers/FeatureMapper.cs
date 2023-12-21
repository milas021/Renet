using Application.Dtos;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public static class FeatureMapper
    {
        public static FeatureDto ToDto(this Feature  feature)
        {
            var dto = new FeatureDto()
            {
                Id = feature.Id,
                Name = feature.Name,
                Value = feature.Value,
            };

            return dto;
        }
    }
}
