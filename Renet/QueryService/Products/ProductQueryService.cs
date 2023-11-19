using IRepositories;
using QueryModel.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryService.Products
{
    public class ProductQueryService
    {
        private readonly IProductRepository productRepository;
        public async Task <IEnumerable<ProductItemDto>> GetAllProduct(int page , int pageSize)
        {
            var result = await productRepository.GetAllProductWithPicture(page, pageSize);
            var dtos = result.Select(x=>x.ToDto()).ToList();
            return dtos;
        }
    }
}
