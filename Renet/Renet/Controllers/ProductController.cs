using Application.QueryServices;
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
        public async Task <IActionResult> GetAllProduct(int page , int pageSize)
        {
            var result =await productQueryService.GetAllProduct(page, pageSize);
            return Ok(result);
        }
    }
}
