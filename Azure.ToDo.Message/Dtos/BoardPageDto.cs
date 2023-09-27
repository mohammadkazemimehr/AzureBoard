using Azure.ToDo.Infrastructure.Enums;

namespace Azure.ToDo.Message.Dtos
{
    public class BoardPageDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<ColumnDto> Columns { get; set; }
    }

    public class ColumnDto
    {
        public Guid Id { get; set; }
        public string title { get; set; }
        public int limit { get; set; }
        public int itemCount { get; set; }
        public List<ColumnItemDto> Items { get; set; }
    }

    public class ColumnItemDto
    {

        public Guid Id { get; set; }
        public ItemType type { get; set; }
        public string title { get; set; }
        public List<ItemTaskDto> Tasks { get; set; }

    }

    public class ItemTaskDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
