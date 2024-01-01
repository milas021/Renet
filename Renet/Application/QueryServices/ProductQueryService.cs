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
        private readonly ICategoryRepository _categoryRepository;

        public ProductQueryService(IProductRepositories productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<PaginationDto<SimpleProductDto>> GetAllProduct(int page, int pageSize , Guid categoryId)
        {
            var products = await _productRepository.GetAllSimpleProduct(page, pageSize ,categoryId);
            var dtos = products.Select(x => x.ToSimpleDto());
            var result = new PaginationDto<SimpleProductDto>()
            {
                Results = dtos,
                TotalRecord = await _productRepository.GetAllSimpleProductCount(categoryId)
            };
            return result;
        }

        public async Task<ProductDto> GetProduct(Guid productId)
        {
            var result = await _productRepository.GetById(productId);
            var dto = result.ToDto();
            return dto;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategories()
        {
            var result = await _categoryRepository.GetAll();
            var dto = result.Select(x => x.ToDto());
            return dto;
        }

    }
}
