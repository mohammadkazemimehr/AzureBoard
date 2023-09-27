namespace Azure.ToDo.Service.Interface
{
    public interface IServiceHolder
    {
        public IBoardService BoardService { get; }
        public IColumnService ColumnService { get; }
        public IColumnItemService ColumnItemService { get; }
        public IAuthenticationService AuthenticationService { get; }
        public ITaskService TaskService { get; }
    }
}
