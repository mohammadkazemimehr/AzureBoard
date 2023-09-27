namespace Azure.ToDo.Repository.Interface
{
    public interface IItemTaskRepository : IRepository<ItemTask>
    {
        Guid Create(ColumnItem baseItem, string title);
    }
}
