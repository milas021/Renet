using Application.QueryServices;
using Domain.Products;
using Infrastructure;
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
        //todo : استفاده برند که یک اینام در دومین است به عنوان کوئری پارامتر زیاد جالب نیست
        [HttpGet()]
        public async Task<IActionResult> GetAllProduct(string? name, Guid categoryId, decimal? minPrice, decimal? maxPrice,[FromQuery]List<Brand> brands ,SortType? sort , int page, int pageSize)
        {
            var result = await productQueryService.GetAllProduct(name, categoryId, minPrice, maxPrice,brands ,sort , page, pageSize);
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
