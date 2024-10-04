using Application.IRepositories;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories {
    public class OrderRepository : Repository, IOrderRepository {
        public OrderRepository(AppDbContext context) : base(context) {
        }

        public async Task<IEnumerable<Order>> GetAll(int page, int pageSize) {
            var skip = (page - 1) * pageSize;
            var order = await _context.Orders
                .Include(x => x.User)
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();
            return order;
        }

        public async Task<int> GetAllOrderCount() {
            var result = await _context.Orders.CountAsync();
            return result;
        }

        public async Task<Order> GetById(Guid id) {
            var order = await _context.Orders
                 .Include(x => x.User)
                 .Include(x => x.OrderItems)
                    .ThenInclude(x => x.Variant)
                    .ThenInclude(x => x.Product)
                 .Include(x => x.OrderItems)
                    .ThenInclude(x => x.Variant)
                    .ThenInclude(x => x.Color)

                 .SingleOrDefaultAsync(x => x.Id == id);
            return order;
        }
    }
}
