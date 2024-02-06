using Application.CommandHandlers;
using Application.Commands;
using Application.QueryServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Renet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly BasketCommandHandler _basketCommandHandler;
        private readonly BasketQueryService _basketQueryService;

      
        public BasketController(BasketCommandHandler basketCommandHandler, BasketQueryService basketQueryService)
        {
            _basketCommandHandler = basketCommandHandler;
            _basketQueryService = basketQueryService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProductToBasket(AddProductToBasketCommand command)
        {
            var result = await _basketCommandHandler.Handle(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserBasket(Guid userId)
        {
            var result = await _basketQueryService.GetUserBasket(userId);
            return Ok(result);
        }
    }
}
