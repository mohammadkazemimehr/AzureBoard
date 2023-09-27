namespace Azure.ToDo.Service.Interface
{
    public interface IBoardService
    {
        Task<ResponseMessage> Post(CreateBoardCommand command,Guid userId);
        Task<ResponseMessage> Put(UpdateBoardCommand command);
        Task Delete(Guid id);
        Task<ResponseMessage> GetBoards(Guid userId);
        Task<ResponseMessage> GetDetail(Guid id);
        Task<ResponseMessage> GetBoardPage(Guid id);
    }
}
