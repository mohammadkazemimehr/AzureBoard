namespace Azure.ToDo.Service.Implimentation.Implimentation
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseMessage> Post(CreateTaskCommand command)
        {
            var baseItem = await _unitOfWork.ColumnItemRepository.FirstOrDefaultAsync(c => c.Id == command.ItemId);
            baseItem.CheckShouldThrowNotFoundException("Item not found");

            var taskId = _unitOfWork.ItemTaskRepository.Create(baseItem, command.Title);

            await _unitOfWork.CommitAsync();

            return ResponseHandler.OkResult("item created successfully", taskId);
        }

        public async Task<ResponseMessage> Put(UpdateTaskCommand command)
        {
            var task = await _unitOfWork.ItemTaskRepository.FirstOrDefaultAsync(c => c.IsActive && c.Id == command.Id);
            task.CheckShouldThrowNotFoundException("task not found");

            task.Title = command.Title;

            await _unitOfWork.CommitAsync();

            return ResponseHandler.OkResult("item updated successfully", task.Id);
        }
    }
}
