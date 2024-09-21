using Application.QueryServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Renet.Controllers.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminUserController : ControllerBase
    {
        private readonly UserQueryService _userQueryService;

        public AdminUserController(UserQueryService userQueryService)
        {
            _userQueryService = userQueryService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllUser(int page , int pageSize)
        {
            var result = await _userQueryService.GetAllUser(page, pageSize);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetUserById(Guid id)
        {
            var result = await _userQueryService.GetUserById(id);
            return Ok(result);
        }
    }
}
