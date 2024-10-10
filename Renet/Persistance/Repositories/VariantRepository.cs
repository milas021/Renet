using Application.IRepositories;
using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories;
public class VariantRepository : Repository, IVariantRepository {
    public VariantRepository(AppDbContext context) : base(context) {
    }

    public async Task<IEnumerable<ProductVariant>> GetVariantsByProductId(Guid productId) {
        var result = await _context.Variants
            .Include(x=>x.Color)
            .Where(x=>x.Product.Id == productId)
            .ToListAsync();
        return result;
    }
}
