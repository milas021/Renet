using Application.IRepositories;
using Domain.Carts;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories;
public class CartItemRepository : Repository, ICartItemRepository {
    public CartItemRepository(AppDbContext context) : base(context) {
    }

    public async Task Add(CartItem cartItem) {
       await _context.AddAsync(cartItem);
    }

    public async Task<CartItem> GetCartItemByVariantAndCart(Guid variantId ,  Guid cartId) {
        var result = await _context.CartItems.SingleOrDefaultAsync(x=>x.VariantId == variantId && x.CartId == cartId);
        return result;
    }
}
