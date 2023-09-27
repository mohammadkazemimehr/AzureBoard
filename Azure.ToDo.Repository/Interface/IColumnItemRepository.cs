using Azure.ToDo.Infrastructure.Enums;

namespace Azure.ToDo.Repository.Interface
{
    public interface IColumnItemRepository : IRepository<ColumnItem>
    {
        Guid Create(Column firstColumn, string title, ItemType type, string description);
    }
}
