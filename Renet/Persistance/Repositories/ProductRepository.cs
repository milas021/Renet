using Application.Dtos;
using Application.IRepositories;
using Domain.Products;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Persistance.Repositories
{
    public class ProductRepository : Repository, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
        
        public async Task<IEnumerable<Product>> GetAllSimpleProduct(string name, Guid categoryId, decimal? minPrice, decimal? maxPrice, List<string> brands, SortType? sort, int page, int pageSize)
        {
            //todo : test this method

            var query = _context.Products
                .Include(x => x.Images)
                .Include(x => x.Category)
                .AsQueryable();

            if (categoryId != Guid.Empty)
                query = query.Where(x => x.Category.Id == categoryId);

            if (!string.IsNullOrEmpty(name))
                query = query.Where(x => x.Name.Contains(name));

            if (minPrice != null)
                query = query.Where(x => x.AnyBiggerPrice(minPrice.Value));

            if (maxPrice != null)
                query = query.Where(x => x.AnySmallerPrice(maxPrice.Value));

            if (brands != null && brands.Count != 0)
                query = query.Where(x => brands.Contains(x.Brand));



            if (sort != null)
            {
                switch (sort)
                {
                    case SortType.Cheapest:
                        {
                            query = query.OrderBy(x => x.GetMinPrice());
                            break;
                        }
                    case SortType.Expensive:
                        {
                            query = query.OrderByDescending(x => x.GetMinPrice());
                            break;
                        }

                }
            }

            var skip = (page - 1) * pageSize;
            var result = query.Skip(skip).Take(pageSize).ToList();
            return result;

        }



        public async Task<int> GetAllSimpleProductCount(string name, Guid categoryId, decimal? minPrice, decimal? maxPrice)
        {

            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(x => x.Name.Contains(name));

            if (categoryId != Guid.Empty)
                query = query.Where(x => x.Category.Id == categoryId);

            if (minPrice != null)
                query = query.Where(x => x.AnyBiggerPrice(minPrice.Value));


            if (maxPrice != null)
                query = query.Where(x => x.AnySmallerPrice(maxPrice.Value));

            var result = await query.CountAsync();
            return result;

        }

        public async Task<Product> GetById(Guid id)
        {
            var result = await _context.Products
                .Include(x => x.Category)
                .Include(x => x.Articles)
                .Include(x => x.Images)
                .Include(x => x.Features)
                .SingleOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task Add(Product product)
        {
            await _context.Products.AddAsync(product);
          
        }

        public async Task<IEnumerable<string>> GetBrands(string? filter)
        {
            var query = _context.Products.AsQueryable().Select(x => x.Brand).Distinct();

            if (filter != null)
                query = query.Where(x => x.Contains(filter));

            var result =await query.ToListAsync();
            return result;
        }


    }

}
