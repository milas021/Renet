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

        public async Task<IEnumerable<Product>> GetAllProduct(int page, int pageSize)
        {
            var skip = (page - 1) * pageSize;
            var result =await _context.Products.Include(x=>x.Pictures).Skip(skip).Take(pageSize).ToListAsync();
            return result;
        }
    }

}
