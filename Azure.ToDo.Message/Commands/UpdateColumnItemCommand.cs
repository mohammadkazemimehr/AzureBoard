using Azure.ToDo.Infrastructure.Enums;

namespace Azure.ToDo.Message.Commands
{
    public class UpdateColumnItemCommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public ItemType Type { get; set; }
        public string Description { get; set; }
    }
}
