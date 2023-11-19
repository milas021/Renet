using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductWithPicture(int page, int pageSize);
        
    }
}
