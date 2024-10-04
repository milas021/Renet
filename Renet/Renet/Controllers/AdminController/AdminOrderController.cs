using Application.QueryServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Renet.Controllers.AdminController {
    [Route("api/[controller]")]
    [ApiController]
    public class AdminOrderController : ControllerBase {
        private readonly OrderQueryService orderQueryService;

        public AdminOrderController(OrderQueryService orderQueryService) {
            this.orderQueryService = orderQueryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page, int pageSize) {
            var result = await orderQueryService.GetAllOrder(page, pageSize);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id) {
            var result = await orderQueryService.GetOrderById(id);
            return Ok(result);
        }
        
    }
}
