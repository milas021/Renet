using Application.Dtos;
using Domain.Products;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories {
    public interface IProductRepository : IRepository {
        Task<IEnumerable<Product>> GetProductIncludedImageAndCategory(string? search, Guid categoryId, int? page, int? pageSize);
        Task<IEnumerable<Product>> GetProductIncludedImageCategoryColorVariant(string? search, Guid categoryId, decimal? minPrice, decimal? maxPrice, List<string> brands,Guid colorId , SortType? sort, int page, int pageSize);
        Task<int> GetProductCount(string? name, Guid categoryId , Guid colorId , decimal? minPrice , decimal? maxPrice , List<string> brands );
        Task<Product> GetById(Guid id);
        Task Add(Product product);
        Task<IEnumerable<string>> GetBrands(string filter);
    }
}
