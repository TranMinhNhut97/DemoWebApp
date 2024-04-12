using DemoWebApp.API.Common;
using DemoWebApp.Application.Common.Entities;
using DemoWebApp.Application.Common.Interface.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebApp.API.Controllers.Identity
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthUserController : ApiControllerBase
    {
        private readonly IIdentityService _identityService;

        public AuthUserController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserModel login)
        {
            var isAuthorization = await _identityService.IsAuthorization(login.UserId, login.PassWord);

            if (isAuthorization) return Ok(true);

            return Unauthorized();
        }
    }
}
