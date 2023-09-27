using Azure.ToDo.Message.Commands;
using Azure.ToDo.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Azure.ToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ApiControllerBase
    {
        private readonly IServiceHolder _serviceHolder;
        public BoardController(IServiceHolder serviceHolder)
        {
            _serviceHolder = serviceHolder;
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] CreateBoardCommand command)
        {
            var result = _serviceHolder.BoardService.Post(command,UserId);
            return Ok(result);
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] UpdateBoardCommand command)
        {
            var result = _serviceHolder.BoardService.Put(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = _serviceHolder.BoardService.Delete(id);
            return OkResult("Bord deleted successfully");
        }

        [HttpGet()]
        public async Task<IActionResult> GetBoards()
        {
            var result = _serviceHolder.BoardService.GetBoards(UserId);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBoardDetail(Guid id)
        {
            var result = _serviceHolder.BoardService.GetDetail(id);
            return Ok(result);
        }

        [HttpGet("Page/{id}")]
        public async Task<IActionResult> GetBoardPage(Guid id)
        {
            var result = _serviceHolder.BoardService.GetBoardPage(id);
            return Ok(result);
        }
    }
}
