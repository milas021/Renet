using Application.Dtos;
using Application.IRepositories;
using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class ProductRepository : Repository, IProductRepositories
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetAllSimpleProduct(int page, int pageSize)
        {
            var skip = (page - 1) * pageSize;
            var result =await _context.Products.Include(x=>x.Pictures).Skip(skip).Take(pageSize).ToListAsync();
            return result;
        }

        public async Task<Product> GetById(Guid id)
        {
            var result = await _context.Products.Include(x => x.Category)
                .Include(x => x.Articles)
                .Include(x => x.Pictures)
                .Include(x => x.Features)
                .SingleOrDefaultAsync(x => x.Id == id);

                return result;
        }
    }

}
