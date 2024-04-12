using DemoWebApp.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebApp.API.Common
{

    [Produces("application/json")]
    public class ApiControllerBase : ControllerBase
    {
        protected IActionResult ResponseResult(ApiResponseResult apiResponseResult)
        {
            if (apiResponseResult.Errors == null || apiResponseResult.Errors.Count == 0) 
            {
                 return HandleApiReponseResult(apiResponseResult);
            }

            return BadRequest(apiResponseResult);
        }

        private IActionResult HandleApiReponseResult(ApiResponseResult apiResponseResult)
        {
            if (apiResponseResult.Data == null) return NoContent();
            return Ok(apiResponseResult);
        }
    }
}
