using Application.CommandHandlers;
using Application.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Renet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly BasketCommandHandler _basketCommandHandler;

        public BasketController(BasketCommandHandler basketCommandHandler)
        {
            _basketCommandHandler = basketCommandHandler;
        }

        [HttpPost]
        public async Task<IActionResult> AddProductToBasket(AddProductToBasketCommand command)
        {
            var result = await _basketCommandHandler.Handle(command);
            return  Ok(result);
        }
    }
}
