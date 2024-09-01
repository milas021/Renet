using Application.CommandHandlers;
using Application.Commands.ProductCommands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Renet.Controllers.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminProductController : ControllerBase
    {
        private readonly ProductCommandHandler _productCommandHandler;

        public AdminProductController(ProductCommandHandler productCommandHandler)
        {
            _productCommandHandler = productCommandHandler;
        }
        [HttpPost("category")]
        public async Task<IActionResult> AddCategory(AddCategoryCommand command)
        {

            var result = await _productCommandHandler.Handle(command);
            return Ok(result);

        }
    }
}
