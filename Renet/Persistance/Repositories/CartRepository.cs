using Application.IRepositories;
using Domain.Carts;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories {
    public class CartRepository : Repository, ICartRepository {
        public CartRepository(AppDbContext context) : base(context) {
        }

        public async Task Add(Cart cart) {
            await _context.AddRangeAsync(cart);
        }

        public async Task<Cart> GetByUserId(Guid userId) {
            var result = await _context.Carts
                 .Include(x => x.CartItems)
                 .SingleOrDefaultAsync(x => x.UserId == userId);
            return result;
        }
    }
}
