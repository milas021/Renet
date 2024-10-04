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
    public class ColorRepository : Repository, IColorRepository
    {
        public ColorRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Color> GetById(Guid id)
        {
            var result = await _context.Colors.SingleOrDefaultAsync(x=>x.Id == id);
            return result;
        }

        public async Task AddColor(Color color) {
            await _context.Colors.AddAsync(color);
        }

        public async Task<bool> AnyColor(string name) {
            var result = await _context.Colors.AnyAsync(x => x.Name == name);
            return result;
        }

        public async Task<IEnumerable<Color>> GetColors(int page, int pageSize) {
            var skip = (page - 1) * pageSize;
            var result = await _context.Colors.Skip(skip).Take(pageSize).ToListAsync();
            return result;
        }
    }
}
