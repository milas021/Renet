using Application.CommandHandlers;
using Application.Commands;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Renet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authCommandHandler;

        public AuthController(AuthService authService)
        {
            _authCommandHandler = authService;
        }


        [HttpPost("Registration")]
        public async Task<IActionResult> Registration(RegistrationCommand command)
        {

            var userAgent = Utilities.GetUserAgentData(this.Request.Headers["User-Agent"]);
            var result = await _authCommandHandler.Registration(command ,userAgent );
            return Ok(result);
        }
    }
}
