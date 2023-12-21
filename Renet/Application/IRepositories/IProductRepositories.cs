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
        Task<IEnumerable<Product>> GetAllSimpleProduct(int page, int pageSize);
        Task<Product> GetById(Guid id);
    }
}
