using Application.Dtos;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDto ToDto(this Category category)
        {
            var dto = new CategoryDto()
            {
                Id = category.Id,
                Name = category.Name,
                Icon = category.Icon,
                Image = category.Image, 
                
            };

            return dto;
        }
             
    }
}
