using Application.IRepositories;
using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class CategoryRepository : Repository, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
        
        public async Task<IEnumerable<Category>> GetAll()
        {
            var result = await _context.Categories.ToListAsync();
            return result;

        }

        public async Task Add(Category category)
        {
            await _context.Categories.AddAsync(category);
           
        }

        public async Task<bool> IsExist(string name)
        {
            var result = await _context.Categories.AnyAsync(c => c.Name == name);
            return result;
        }

        public async Task<Category> GetById(Guid id)
        {
            var result = await _context.Categories.SingleOrDefaultAsync(x => x.Id == id);
            return result;

        }
    }
}
