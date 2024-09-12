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
    }
}
