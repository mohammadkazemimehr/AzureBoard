using Azure.ToDo.Infrastructure.Enums;

namespace Azure.ToDo.Domain.Entities
{
    public class ColumnItem : BaseEntity
    {
        public string Title { get; set; }
        public ItemType Type { get; set; }
        public string Description { get; set; }
        public Column Column { get; set; }
        public List<ItemTask> Tasks { get; set; }
    }
}
