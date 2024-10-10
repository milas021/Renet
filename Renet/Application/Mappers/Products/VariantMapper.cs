using Application.Dtos.Products;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers.Products;
public static class VariantMapper {
    public static ProductVariantDto ToDto(this ProductVariant variant) {
        var dto = new ProductVariantDto() {
            Color = variant.Color.Name,
            Name = variant.Product.Name,
            Id = variant.Id,
            Price = variant.Price,
            
        };

        return dto;
    }

    public static VariantDto ToVariantDto(this ProductVariant variant) {
        var dto = new VariantDto {
            Color = variant.Color.Name,
            Id = variant.Id,
            Price = variant.Price,
            Stock = variant.Stock,
        };
        return dto;
    }

   
}

