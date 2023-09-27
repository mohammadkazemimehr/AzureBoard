using Microsoft.AspNetCore.Mvc;

namespace Azure.ToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColumnController : ApiControllerBase
    {
        private readonly IServiceHolder _serviceHolder;
        public ColumnController(IServiceHolder serviceHolder)
        {
            _serviceHolder = serviceHolder;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateColumnCommand command)
        {
            var result = await _serviceHolder.ColumnService.Post(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateColumnCommand command)
        {
            var result = await _serviceHolder.ColumnService.Put(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetail(Guid id)
        {
            var result = await _serviceHolder.ColumnService.GetDetail(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _serviceHolder.ColumnService.Delete(id);
            return Ok(result);
        }
    }
}
