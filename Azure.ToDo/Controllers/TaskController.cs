using Microsoft.AspNetCore.Mvc;

namespace Azure.ToDo.Controllers
{
    [Route("api/ToDoList/[controller]")]
    [ApiController]
    public class TaskController : ApiControllerBase
    {
        private readonly IServiceHolder _serviceHolder;
        public TaskController(IServiceHolder serviceHolder)
        {
            _serviceHolder = serviceHolder;
        }

        [HttpPost()]
        public async Task<IActionResult> Post(CreateTaskCommand command)
        {
            var result = await _serviceHolder.TaskService.Post(command);
            return Ok(result);
        }

        [HttpPut()]
        public async Task<IActionResult> Put(UpdateTaskCommand command)
        {
            var result = await _serviceHolder.TaskService.Put(command);
            return Ok(result);
        }
    }
}
