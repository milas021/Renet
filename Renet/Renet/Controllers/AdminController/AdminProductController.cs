using Application.CommandHandlers;
using Application.Commands.ProductCommands;
using Application.QueryServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Renet.Controllers.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminProductController : ControllerBase
    {
        private readonly ProductCommandHandler _productCommandHandler;
        private readonly ProductQueryService _productQueryService;

        public AdminProductController(ProductCommandHandler productCommandHandler, ProductQueryService productQueryService)
        {
            _productCommandHandler = productCommandHandler;
            _productQueryService = productQueryService;
        }
        [HttpPost("category")]
        public async Task<IActionResult> AddCategory(AddCategoryCommand command)
        {

            var result = await _productCommandHandler.Handle(command);
            return Ok(result);

        }

        [HttpPut("category")]
        public async Task<IActionResult> EditCategory(EditCategoryCommand command)
        {
            var result = await _productCommandHandler.Handle(command);
            return Ok(result);
        }
        [HttpPost("product")]
        public async Task<IActionResult> AddProduct (AddProductCommand command)
        {
            var result = await _productCommandHandler.Handle(command);
            return Ok(result);
        }

        [HttpGet("category")]
        public async Task<IActionResult> GetCategory()
        {
            var result = await _productQueryService.GetAllCategories();
            return Ok(result);
        }

        [HttpGet("product/brand")]
        public async Task<IActionResult> GetBrands(string? filter)
        {
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
