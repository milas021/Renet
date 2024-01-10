using Application.QueryServices;
using Domain.Products;
using Microsoft.AspNetCore.Mvc;

namespace Renet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductQueryService productQueryService;

        public ProductController(ProductQueryService productQueryService)
        {
            this.productQueryService = productQueryService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllProduct(string? name, Guid categoryId, double? minPrice, double? maxPrice,[FromQuery]List<Brand> brands , int page, int pageSize)
        {
            var result = await productQueryService.GetAllProduct(name, categoryId, minPrice, maxPrice,brands ,page, pageSize);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var result = await productQueryService.GetProduct(id);
            return Ok(result);
        }
        [HttpGet("category")]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await productQueryService.GetAllCategories();
            return Ok(result);
        }
    }
}
