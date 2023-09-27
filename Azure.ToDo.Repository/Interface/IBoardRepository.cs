
namespace Azure.ToDo.Repository.Interface
{
    public interface IBoardRepository : IRepository<Board>
    {
        Task<Guid> CreateBoard(string name, User user);
    }
}
