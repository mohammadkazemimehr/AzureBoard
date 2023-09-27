namespace Azure.ToDo.Repository.Interface
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        public IBoardRepository BoardRepository { get; }
        public IColumnRepository ColumnRepository { get; }
        public IColumnItemRepository ColumnItemRepository { get; }
        public IItemTaskRepository ItemTaskRepository { get; }
        Task<int> CommitAsync();
    }
}
