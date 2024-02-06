using Application.Dtos;
using Application.IRepositories;
using Application.Mappers;
using Domain.Products;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.QueryServices
{
    public class ProductQueryService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductQueryService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<PaginationDto<SimpleProductDto>> GetAllProduct(string name, Guid categoryId, decimal? minPrice, decimal? maxPrice, List<Brand> brands , SortType? sort , int page, int pageSize)
        {
            var products = await _productRepository.GetAllSimpleProduct(name, categoryId, minPrice, maxPrice,brands ,sort, page, pageSize);
            var dtos = products.Select(x => x.ToSimpleDto());
            var result = new PaginationDto<SimpleProductDto>()
            {
                Results = dtos,
                TotalRecord = await _productRepository.GetAllSimpleProductCount(name ,categoryId ,minPrice ,maxPrice)
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
