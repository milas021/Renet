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
public class FeatureRepository : Repository, IFeatureRepository {
    public FeatureRepository(AppDbContext context) : base(context) {
    }

    public async Task<IEnumerable<Feature>> GetByProductId(Guid productId) {
       var result = await _context.Features.Where(x=>x.ProductId ==productId).ToListAsync();
        return result;
    }
}
