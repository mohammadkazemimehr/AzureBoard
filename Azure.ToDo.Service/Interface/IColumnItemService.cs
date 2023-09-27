namespace Azure.ToDo.Service.Interface
{
    public interface IColumnItemService
    {
        Task<ResponseMessage> Post(AddColumnItemCommand command);
        Task<ResponseMessage> Put(UpdateColumnItemCommand command);
        Task<ResponseMessage> Delete(Guid id);
        Task<ResponseMessage> GetDetail(Guid id);
        Task<ResponseMessage> ChangeColumn(ChangeColumnCommand command);
    }
}
