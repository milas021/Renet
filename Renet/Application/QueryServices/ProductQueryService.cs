using Application.Dtos;
using Application.IRepositories;
using Application.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.QueryServices
{
    public class ProductQueryService
    {
        private readonly IProductRepositories _productRepository;

        public ProductQueryService(IProductRepositories productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductItemDto>> GetAllProduct(int page, int pageSize)
        {
            var result = await _productRepository.GetAllProduct(page, pageSize);
            var dtos = result.Select(x => x.ToDto());
            return dtos;
        }
    }
}
