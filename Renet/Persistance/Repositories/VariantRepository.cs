using Application.IRepositories;
using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories;
public class VariantRepository : Repository, IVariantRepository {
    public VariantRepository(AppDbContext context) : base(context) {
    }

    public async Task<Variant> GetById(Guid id) {
        var result = await _context.Variants.SingleOrDefaultAsync(x=>x.Id == id);
        return result;
    }

    public async Task<IEnumerable<Variant>> GetVariantsByProductId(Guid productId) {
        var result = await _context.Variants
            .Include(x=>x.Color)
            .Where(x=>x.Product.Id == productId)
            .ToListAsync();
        return result;
    }
}
