using Application.Dtos;
using Domain.Products;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    public interface IProductRepository : IRepository
    {
        Task<IEnumerable<Product>> GetAllSimpleProduct(string name, Guid categoryId, decimal? minPrice, decimal? maxPrice, List<string> brands, SortType? sort, int page, int pageSize);
        Task<int> GetAllSimpleProductCount(string name, Guid categoryId, decimal? minPrice, decimal? maxPrice);
        Task<Product> GetById(Guid id);
        Task Add(Product product);
        Task<IEnumerable<string>> GetBrands(string filter);
    }
}
