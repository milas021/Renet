using Application.Dtos.Orders;
using Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories {
    public interface IOrderRepository {
        Task<IEnumerable<Order>> GetAll(int page, int pageSize);
        Task<Order> GetById(Guid id);
    }
}
