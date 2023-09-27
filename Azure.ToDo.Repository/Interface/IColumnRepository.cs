namespace Azure.ToDo.Repository.Interface
{
    public interface IColumnRepository : IRepository<Column>
    {
        Guid Create(Board board, string title, int limit);
    }
}
