using Application.CommandHandlers;
using Application.Commands.ProductCommands;
using Application.QueryServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Renet.Controllers.AdminController {
    [Route("api/[controller]")]
    [ApiController]
    public class AdminProductController : ControllerBase {
        private readonly ProductCommandHandler _productCommandHandler;
        private readonly ProductQueryService _productQueryService;

        public AdminProductController(ProductCommandHandler productCommandHandler, ProductQueryService productQueryService) {
            _productCommandHandler = productCommandHandler;
            _productQueryService = productQueryService;
        }
        [HttpPost("category")]
        public async Task<IActionResult> AddCategory(AddCategoryCommand command) {

            var result = await _productCommandHandler.Handle(command);
            return Ok(result);

        }

        [HttpPut("category")]
        public async Task<IActionResult> EditCategory(EditCategoryCommand command) {
            var result = await _productCommandHandler.Handle(command);
            return Ok(result);
        }

        [HttpGet("category")]
        public async Task<IActionResult> GetCategory() {
            var result = await _productQueryService.GetAllCategories();
            return Ok(result);
        }

        [HttpPost("product")]
        public async Task<IActionResult> AddProduct(AddProductCommand command) {
            var result = await _productCommandHandler.Handle(command);
            return Ok(result);
        }

        [HttpGet("Product")]
        public async Task<IActionResult> GetAllProduct(string? search, Guid categoryId, int page = 1, int pageSize = 10) {

            var result = await _productQueryService.GetProductByFilter(search, categoryId, page, pageSize);
            return Ok(result);
        }

        [HttpGet("Product/{id}")]
        public async Task<IActionResult> GetById(Guid id) {

            var result = await _productQueryService.GetProductById(id);
            return Ok(result);
        }

        [HttpGet("Peoduct/Article/{productId}")]
        public async Task<IActionResult> GetArticleByProductId(Guid productId) {

            var result = await _productQueryService.GetArticleByProductId(productId);
            return Ok(result);
        }

        [HttpGet("Product/Feature/{productId}")]
        public async Task<IActionResult>  GetFeaturesbyProductId(Guid productId) {

            var result = await _productQueryService.GetFeatureByProductId(productId);
            return Ok(result);
        }

        [HttpGet("Product/Variant/{productId}")]
        public async Task<IActionResult> GetVariantsByProductId(Guid productId) {

            var result = await _productQueryService.GetVariantsByProductId(productId);
                return Ok(result);
        }

        [HttpGet("Product/Image/{productId}")]
        public async Task< IActionResult> GetImagesByProductId(Guid productId) {
            var result = await _productQueryService.GetImagesByProductId(productId);
            return Ok(result);
        }


        [HttpGet("product/brand")]
        public async Task<IActionResult> GetBrands(string? filter) {
            var result = await _productQueryService.GetBrands(filter);
            return Ok(result);
        }

        [HttpPost("color")]
        public async Task<IActionResult> AddColor(AddColorCommand command) {
            var result = await _productCommandHandler.Handle(command);
            return Ok(result);
        }

        [HttpGet("color")]
        public async Task<IActionResult> GetAllColors(int page, int pageSize) {
            var result = await _productQueryService.GetAllColor(page, pageSize);
            return Ok(result);
        }
    }



}
