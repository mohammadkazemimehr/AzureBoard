namespace Azure.ToDo.Service.Interface
{
    public interface ITaskService
    {
        Task<ResponseMessage> Post(CreateTaskCommand command);
        Task<ResponseMessage> Put(UpdateTaskCommand command);
    }
}
