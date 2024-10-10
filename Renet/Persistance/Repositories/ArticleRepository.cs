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
public class ArticleRepository : Repository, IArticleRepository {
    public ArticleRepository(AppDbContext context) : base(context) {
    }

    public async Task<IEnumerable<Article>> GetByProductId(Guid productId) {

        var result = await _context.Articles.Where(x => x.ProductId == productId).ToListAsync();
        return result;
    }
}
