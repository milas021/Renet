using Application.Dtos;
using Application.Dtos.Products;
using Application.IRepositories;
using Application.Mappers;
using Application.Mappers.Products;
using Infrastructure;

namespace Application.QueryServices {
    public class ProductQueryService {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IColorRepository _colorRepository;
        private readonly IArticleRepository _articleRepository;
        private readonly IFeatureRepository _featureRepository;
        private readonly IVariantRepository _variantRepository;
        private readonly IImageRepository _imageRepository;


        public ProductQueryService(IProductRepository productRepository, ICategoryRepository categoryRepository, IColorRepository colorRepository, IArticleRepository articleRepository, IFeatureRepository featureRepository, IVariantRepository variantRepository, IImageRepository imageRepository) {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _colorRepository = colorRepository;
            _articleRepository = articleRepository;
            _featureRepository = featureRepository;
            _variantRepository = variantRepository;
            _imageRepository = imageRepository;
        }

        public async Task<PaginationDto<SimpleProductAdminDto>> GetProductByFilter(string? search, Guid categoryId, int? page, int? pageSize) {

            var products = await _productRepository.GetProductIncludedImageAndCategory(search, categoryId, page, pageSize);

            var dtos = products.Select(x => x.ToSimpleDto());
            var result = new PaginationDto<SimpleProductAdminDto>() {
                Results = dtos,
                TotalRecord = await _productRepository.GetProductCount(search, categoryId, Guid.Empty, null, null, null)
            };
            return result;
        }
        public async Task<PaginationDto<SimpleProductCustomerDto>> GetAllProduct(string? search, Guid categoryId, decimal? minPrice, decimal? maxPrice, List<string> brands, Guid colorId, SortType? sort, int page, int pageSize) {

            var products = await _productRepository.GetProductIncludedImageCategoryColorVariant(search, categoryId, minPrice, maxPrice, brands, colorId, sort, page, pageSize);
            var dtos = products.Select(x => x.ToSimpleCustomerDto());
            var total = await _productRepository.GetProductCount(search, categoryId, colorId, minPrice, maxPrice, brands);
            var result = new PaginationDto<SimpleProductCustomerDto> {
                Results = dtos,
                TotalRecord = total
            };
            return result;

        }

        public async Task<ProductDto> GetProductById(Guid id) {
            var result = await _productRepository.GetById(id);
            var dto = result.ToDto();
            return dto;
        }

      

        public async Task<IEnumerable<ArticleDto>> GetArticleByProductId(Guid productId) {
            var result = await _articleRepository.GetByProductId(productId);
            var dto = result.Select(x => x.ToDto()).ToList();
            return dto;
        }

        public async Task<IEnumerable<FeatureDto>> GetFeatureByProductId(Guid productId) {
            var result = await _featureRepository.GetByProductId(productId);
            var dto = result.Select(x => x.ToDto()).ToList();
            return dto;
        }

        public async Task<IEnumerable<VariantDto>> GetVariantsByProductId(Guid productId) {
            var result = await _variantRepository.GetVariantsByProductId(productId);
            var dto = result.Select(x => x.ToDto()).ToList();
            return dto;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategories() {
            var result = await _categoryRepository.GetAll();
            var dto = result.Select(x => x.ToDto());
            return dto;
        }

        public async Task<IEnumerable<ProductPictureDto>> GetImagesByProductId(Guid productId) {
            var result = await _imageRepository.GetImagedByProductId(productId);
            var dto = result.Select(x => x.ToDto());
            return dto;

        }

        public async Task<IEnumerable<string>> GetBrands(string? filter) {
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
