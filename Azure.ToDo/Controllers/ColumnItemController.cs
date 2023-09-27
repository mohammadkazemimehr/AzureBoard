using Microsoft.AspNetCore.Mvc;

namespace Azure.ToDo.Controllers
{
    [Route("api/ToDoList/[controller]")]
    [ApiController]
    public class ColumnItemController : ApiControllerBase
    {
        private readonly IServiceHolder _serviceHolder;
        public ColumnItemController(IServiceHolder serviceHolder)
        {
            _serviceHolder = serviceHolder;
        }
        [HttpPost()]
        public async Task<IActionResult> Post(AddColumnItemCommand command)
        {
            var result = await _serviceHolder.ColumnItemService.Post(command);
            return Ok(result);
        }

        [HttpPut()]
        public async Task<IActionResult> Put(UpdateColumnItemCommand command)
        {
            var result = await _serviceHolder.ColumnItemService.Put(command);
            return Ok(result);
        }

        [HttpDelete("/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _serviceHolder.ColumnItemService.Delete(id);
            return Ok(result);
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetDetail(Guid id)
        {
            var result = await _serviceHolder.ColumnItemService.GetDetail(id);
            return Ok(result);
        }

        [HttpPut("ChangeColumn")]
        public async Task<IActionResult> ChangeColumn([FromBody] ChangeColumnCommand command)
        {
            var result = await _serviceHolder.ColumnItemService.ChangeColumn(command);
            return Ok(result);
        }
    }
}
