using Application.CommandHandlers;
using Application.Commands;
using Application.Dtos;
using Domain.Tokens;
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
        private const string refreshTokenKey = "RefreshToken";

        public AuthController(AuthService authService)
        {
            _authCommandHandler = authService;
        }


        [HttpPost(nameof(Registration))]
        public async Task<IActionResult> Registration(RegistrationCommand command)
        {
            var userAgent = Utilities.GetUserAgentData(this.Request.Headers["User-Agent"]);
            var result = await _authCommandHandler.Registration(command, userAgent);
            AddRefreshTokenCookie(result.Tokens);
            return Ok(result);
        }

        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            var userAgent = Utilities.GetUserAgentData(this.Request.Headers["User-Agent"]);
            var result = await _authCommandHandler.Login(command, userAgent);
            AddRefreshTokenCookie(result.Tokens);
            return Ok(result);
        }

        [HttpDelete(nameof(Logout))]
        public async Task<IActionResult> Logout()
        {
            var cookieExist = this.Request.Cookies.TryGetValue(refreshTokenKey, out var refreshTokenValue);
            if (!cookieExist)
                throw new Exception("رفرش توکن یافت نشد");

            await _authCommandHandler.Logout(refreshTokenValue);

            this.Response.Cookies.Delete(refreshTokenKey);

            return Ok();
        }

        [HttpPut(nameof(Refresh))]
        public async Task<IActionResult> Refresh(RefreshTokenCommand command)
        {
            var cookieExist = this.Request.Cookies.TryGetValue(refreshTokenKey, out var refreshTokenValue);
            if (!cookieExist)
                throw new Exception("رفرش توکن یافت نشد");

            var userAgent = Utilities.GetUserAgentData(this.Request.Headers["User-Agent"]);

            var result = await _authCommandHandler.Refresh(command.AccessToken,refreshTokenValue ,userAgent );
            AddRefreshTokenCookie(result.Tokens);

            return Ok(result);
        }


        #region Private Methods

        private void AddRefreshTokenCookie(TokenDto token)
        {
            var cookieOptions = new CookieOptions
            {
                Expires = token.Expired,
                MaxAge = TimeSpan.FromMinutes(token.LifeTime)
            };
            Response.Cookies.Append(refreshTokenKey, token.RefreshToken, cookieOptions);
        }

        #endregion

    }
}
