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
        Task<IEnumerable<Product>> GetAllProduct(int page, int pageSize);
    }
}
