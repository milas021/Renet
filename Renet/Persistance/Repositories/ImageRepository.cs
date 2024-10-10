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
public class ImageRepository : Repository, IImageRepository {
    public ImageRepository(AppDbContext context) : base(context) {
    }

    public async Task<IEnumerable<ProductImage>> GetImagedByProductId(Guid productId) {
        var result = await _context.ProductPictures.Where(x=>x.ProductId == productId).ToListAsync();
        return result;
    }
}
