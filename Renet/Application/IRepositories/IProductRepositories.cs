using Application.Dtos;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    public interface IProductRepositories
    {
        Task<IEnumerable<Product>> GetAllSimpleProduct(string name, Guid categoryId, double? minPrice, double? maxPrice, List<Brand> brands,  int page, int pageSize);
        Task<int> GetAllSimpleProductCount(string name, Guid categoryId, double? minPrice, double? maxPrice);
        Task<Product> GetById(Guid id);
    }
}
