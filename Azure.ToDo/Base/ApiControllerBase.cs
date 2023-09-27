using Azure.ToDo.Base.Helpers;
using Azure.ToDo.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Azure.ToDo.Base
{
    [ApiController]
    [Authorize]
    public class ApiControllerBase : ControllerBase
    {

        protected string GetAccessToken(HttpRequest httpRequest) => httpRequest.Headers.ContainsKey("Authorization")
                                                        ? httpRequest.Headers["Authorization"].ToString().Split(" ")[1]
                                                        : string.Empty;
        protected string AccessToken => GetAccessToken(Request);
        protected virtual string UserName => ClaimHelper.GetUserName(this.AccessToken);
        protected virtual Guid UserId => ClaimHelper.GetUserId(this.AccessToken);

        protected ApiControllerBase()
        {
        }

        #region responses 
        [NonAction]
        public BadRequestObjectResult BadRequest(string message)
        {
            return BadRequest(new { Message = message });
        }

        [NonAction]
        public NotFoundObjectResult NotFound(string message)
        {
            return NotFound(new { Message = message });
        }
        [NonAction]
        protected virtual IActionResult OkResult(string message)
        {
            return this.OkResult(message, null);
        }
        [NonAction]
        protected virtual IActionResult OkResult(string message, object content)
        {
            return Ok(new ResponseMessage(message, content));
        }

        [NonAction]
        protected virtual IActionResult OkResult(string message, object content, int total)
        {
            return Ok(new ResponseMessage(message, content, total));
        }
        #endregion
    }
}
