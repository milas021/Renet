using Application.Dtos.Orders;
using Domain.Orders;
using Infrastructure.Extentions;

namespace Application.Mappers.Orders;
public static class OrderMapper {

    public static BasicOrderDto ToBasicDto(this Order order) {
        var basicOrderDto = new BasicOrderDto() {
            CustomerName = order.User.FirstName + " " + order.User.LastName,
            CustomerProvince = order.User.Province.GetDescription(),
            Id = order.Id,
            Number = order.Number,
            OrderDate = order.OrderDate.ToPersianDate()
        };

        return basicOrderDto;
    }

    public static OrderDto ToDto(this Order order) {
        var dto = new OrderDto();
        dto.Id = order.Id;
        dto.Number = order.Number;
        dto.OrderDate = order.OrderDate.ToPersianDate();
        dto.Status = order.Status.ToString();
        dto.TotalPrice = order.TotalPrice;
        dto.User = order.User.ToBasicDto();
        dto.OrderItems = order.OrderItems.Select(x => x.ToDto());

        return dto;
    }
}
