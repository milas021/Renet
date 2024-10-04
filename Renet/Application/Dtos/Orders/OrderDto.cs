using Application.Dtos.Users;

namespace Application.Dtos.Orders;
public class OrderDto {
    public Guid Id { get; set; }
    public int Number { get; set; }
    public BasicUserDto User { get; set; }
    public string OrderDate { get; set; }
    public decimal TotalPrice { get;  set; }
    public string Status { get;  set; }
    public IEnumerable<OrderItemDto> OrderItems { get;  set; }
}

