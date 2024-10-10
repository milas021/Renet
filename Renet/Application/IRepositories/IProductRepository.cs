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
       
        Task<int> GetProductCount(string? name, Guid categoryId);
        Task<Product> GetById(Guid id);
        Task Add(Product product);
        Task<IEnumerable<string>> GetBrands(string filter);
    }
}
