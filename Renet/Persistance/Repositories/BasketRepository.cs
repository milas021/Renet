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
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public async Task Add(Basket basket)
        {
            await _context.Baskets.AddAsync(basket);
        }

        public async Task UpdateEntityAsync(Basket entity)
        {
            // Attach the entity to the context if it's not already tracked
            if (!_context.Set<Basket>().Local.Any(e => e.Id == entity.Id))
            {
                _context.Set<Basket>().Attach(entity);
            }

            // Mark the entity as modified
            _context.Entry(entity).State = EntityState.Modified;


            // Save changes to the database
            _context.ChangeTracker.DetectChanges();
            await _context.SaveChangesAsync();
        }

        public async Task<Basket> GetByUserId(Guid userId)
        {
            var result = await _context.Baskets
                .Include(x => x.Items)
                .SingleOrDefaultAsync(x => x.UserId == userId);

            return result;
        }
    }
}
