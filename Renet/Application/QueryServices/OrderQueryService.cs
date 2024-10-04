using Application.Dtos;
using Application.Dtos.Orders;
using Application.IRepositories;
using Application.Mappers;
using Application.Mappers.Orders;

namespace Application.QueryServices {
    public class OrderQueryService {
        private readonly IOrderRepository _orderRepository;

        public OrderQueryService(IOrderRepository orderRepository) {
            _orderRepository = orderRepository;
        }

        public async Task<PaginationDto< BasicOrderDto>> GetAllOrder(int page, int pageSize) {
            var order = await _orderRepository.GetAll(page, pageSize);

            var dto = order.Select(x => x.ToBasicDto()).ToList();
            var result = new PaginationDto<BasicOrderDto>() {
                Results = dto,
                TotalRecord = await _orderRepository.GetAllOrderCount()
            };
            return result;

        }

        public async Task<OrderDto> GetOrderById(Guid id) {
            var order = await _orderRepository.GetById(id);
            var dto = order.ToDto();
            return dto;

        }
    }
}
