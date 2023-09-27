using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Azure.ToDoList.Controllers
{
    [Route("api/ToDoList/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : ApiControllerBase
    {
        private readonly IServiceHolder _serviceHolder;

        public AuthenticationController(IServiceHolder serviceHolder)
        {
            _serviceHolder = serviceHolder;
        }

        [HttpPut("Login")]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            var result = await _serviceHolder.AuthenticationService.Login(command);
            return Ok(result);
        }

        [HttpPost("Signup")]
        public async Task<IActionResult> SignUp(SignUpCommand command)
        {
            var result = await _serviceHolder.AuthenticationService.SignUp(command);
            return Ok(result);
        }
    }
}
