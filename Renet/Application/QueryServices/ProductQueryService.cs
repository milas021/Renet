using Application.Dtos;
using Application.Dtos.Products;
using Application.IRepositories;
using Application.Mappers;
using Application.Mappers.Products;
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
        private readonly IColorRepository _colorRepository;


        public ProductQueryService(IProductRepository productRepository, ICategoryRepository categoryRepository, IColorRepository colorRepository) {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _colorRepository = colorRepository;
        }

        public async Task<PaginationDto<SimpleProductDto>> GetAllProduct(string name, Guid categoryId, decimal? minPrice, decimal? maxPrice, List<string> brands , SortType? sort , int page, int pageSize)
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

        public async Task<IEnumerable<string>> GetBrands(string? filter)
        {
            var result = await _productRepository.GetBrands(filter);
            return result;
            
        }

        public async Task<IEnumerable<ColorDto>> GetAllColor(int page, int pageSize) {
            var result = await _colorRepository.GetColors(page, pageSize);
            var dto = result.Select(x => x.ToDto());
            return dto;
        }

    }
}
