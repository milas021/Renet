using Application.IRepositories;
using Domain.Baskets;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class BasketRepository : Repository, IBasketRepository
    {
        public BasketRepository(AppDbContext context) : base(context)
        {
        }

        public async Task Add(Basket basket)
        {
            await _context.Baskets.AddAsync(basket);
            await _context.SaveChangesAsync();
        }

        public async Task<Basket> GetByUserId(Guid userId)
        {
            var result = await _context.Baskets.Where(x => x.UserId == userId).SingleOrDefaultAsync();
            return result;
        }
    }
}
