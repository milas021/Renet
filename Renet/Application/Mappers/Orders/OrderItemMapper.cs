using Application.Dtos;
using Application.Dtos.Orders;
using Application.Mappers.Products;
using Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers.Orders {
    public static class OrderItemMapper {
        public static OrderItemDto ToDto(this OrderItem item) {
            var dto = new OrderItemDto() {
                Id = item.Id,
                Price = item.Price,
                Quantity = item.Quantity,
                Product = item.Variant.ToDto(),
            };
            return dto;
        }
    }
}
