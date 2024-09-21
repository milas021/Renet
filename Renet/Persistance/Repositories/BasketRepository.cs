using Application.IRepositories;
using Domain.Baskets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        }

        

        public async Task<Basket> GetByUserId(Guid userId)
        {
            var result = await _context.Baskets
                .Include(x => x.Items)
                .SingleOrDefaultAsync(x => x.UserId == userId);

            return result;
        }

        public async Task AddBasketItemToBasket(Basket basket, BasketItem item)
        {
            basket.AddToBasket(item);
            _context.Entry(item).State = EntityState.Added;

        }
    }
}
