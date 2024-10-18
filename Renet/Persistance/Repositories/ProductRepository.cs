using Application.IRepositories;
using Domain.Products;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories {
    public class ProductRepository : Repository, IProductRepository {
        public ProductRepository(AppDbContext context) : base(context) {
        }

        public async Task<IEnumerable<Product>> GetProductIncludedImageAndCategory(string? search, Guid categoryId, int? page, int? pageSize) {

            var query = _context.Products
                .Include(x => x.Images)
                .Include(x => x.Category)
                .AsQueryable();

            if (categoryId != Guid.Empty)
                query = query.Where(x => x.Category.Id == categoryId);

            if (!string.IsNullOrEmpty(search))
                query = query.Where(x => x.Name.Contains(search) || x.Brand.Contains(search));

            var skip = (page - 1) * pageSize;
            var result = query.Skip(skip.Value).Take(pageSize.Value).ToList();
            return result;

        }



        public async Task<int> GetProductCount(string? search, Guid categoryId , Guid colorId, decimal? minPrice, decimal? maxPrice, List<string> brands) {

            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(search))
                query = query.Where(x => x.Name.Contains(search) || x.Brand.Contains(search));

            if (categoryId != Guid.Empty)
                query = query.Where(x => x.Category.Id == categoryId);

            if (colorId != Guid.Empty)
                query = query.Where(x => x.Variants.Any(x => x.Color.Id == colorId));

            if (brands != null && brands.Count != 0)
                query = query.Where(x => brands.Contains(x.Brand));

            if (minPrice != null)
                query = query.Where(x => x.Variants.Min(x => x.Price) >= minPrice);

            if (maxPrice != null)
                query = query.Where(x => x.Variants.Max(x => x.Price) <= maxPrice);

            var result = await query.CountAsync();
            return result;

        }

        public async Task<Product> GetById(Guid id) {
            var result = await _context.Products
                .Include(x => x.Category)
                .Include(x => x.Articles)
                .Include(x => x.Images)
                .Include(x=>x.Variants)
                    .ThenInclude(x=>x.Color)
                .Include(x => x.Features)
                .SingleOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task Add(Product product) {
            await _context.Products.AddAsync(product);

        }

        public async Task<IEnumerable<string>> GetBrands(string? filter) {
            var query = _context.Products.AsQueryable().Select(x => x.Brand).Distinct();

            if (filter != null)
                query = query.Where(x => x.Contains(filter));

            var result = await query.ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Product>> GetProductIncludedImageCategoryColorVariant(string? search, Guid categoryId, decimal? minPrice, decimal? maxPrice, List<string> brands,Guid colorId ,  SortType? sort, int page, int pageSize) {

            var query = _context.Products
               .Include(x => x.Images)
               .Include(x => x.Category)
               .Include(x => x.Variants)
                .ThenInclude(x => x.Color)
               .AsQueryable();

            if (categoryId != Guid.Empty)
                query = query.Where(x => x.Category.Id == categoryId);

            if (!string.IsNullOrEmpty(search))
                query = query.Where(x => x.Name.Contains(search) || x.Brand.Contains(search));

            if(brands != null && brands.Count != 0 )
                query = query.Where(x=> brands.Contains(x.Brand));

            if (minPrice != null )
                query = query.Where(x=> x.Variants.Min(x => x.Price) >= minPrice);

            if (maxPrice != null )
                query = query.Where(x=> x.Variants.Max(x => x.Price) <= maxPrice);

            if (colorId != Guid.Empty)
                query = query.Where(x =>x.Variants.Any(x=> x.Color.Id == colorId));

            if(sort != null) {
                switch (sort) {
                    case SortType.Cheapest: {
                            query = query.OrderBy(x => x.Variants.Min(x => x.Price));
                            break;
                        }
                    case SortType.Expensive: {
                            query = query.OrderByDescending(x => x.Variants.Min(x => x.Price));
                            break;
                        }

                }
            }

            var skip = (page - 1) * pageSize;
            var result = query.Skip(skip).Take(pageSize).ToList();
            return result;
        }

        
    }

}
