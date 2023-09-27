using Microsoft.Extensions.Configuration;

namespace Azure.ToDo.Service.Implimentation.Implimentation
{
    public class ServiceHolder : IServiceHolder
    {
        private IBoardService _boardService;
        private IColumnService _columnService;
        private IColumnItemService _columnItemService;
        private IAuthenticationService _authenticationService;
        private ITaskService _taskService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        
        public ServiceHolder(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public IBoardService BoardService => _boardService = _boardService ?? new BoardService(_unitOfWork);
        public IColumnService ColumnService => _columnService = _columnService ?? new ColumnService(_unitOfWork);
        public IColumnItemService ColumnItemService => _columnItemService = _columnItemService ?? new ColumnItemService(_unitOfWork);
        public IAuthenticationService AuthenticationService => _authenticationService = _authenticationService ?? new AuthenticationService(_unitOfWork, _configuration);
        public ITaskService TaskService => _taskService = _taskService ?? new TaskService(_unitOfWork);
    }
}
