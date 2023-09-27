namespace Azure.ToDo.Service.Interface
{
    public interface IColumnService
    {
        Task<ResponseMessage> Post(CreateColumnCommand command);
        Task<ResponseMessage> Put(UpdateColumnCommand command);
        Task<ResponseMessage> GetDetail(Guid id);
        Task<ResponseMessage> Delete(Guid id);
    }
}
