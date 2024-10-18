using Application.CommandHandlers;
using Application.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Renet.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CartController : ControllerBase {

    private readonly CartCommandHandler _cartCommandHandler;

    public CartController(CartCommandHandler cartCommandHandler) {
        _cartCommandHandler = cartCommandHandler;
    }

    [HttpPost]
    public async Task<IActionResult> AddProductToBasket(AddProductToBasketCommand command) {

        var result = await _cartCommandHandler.Handle(command);
        return Ok(result);
    }
}
