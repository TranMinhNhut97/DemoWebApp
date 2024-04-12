using DemoWebApp.API.Common;
using DemoWebApp.Application.Common.Interface.Application;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebApp.API.Controllers.Identity
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ApiControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var result = await _userService.GetUsersByUserId(id);
            return Ok(result);
        }
    }
}
