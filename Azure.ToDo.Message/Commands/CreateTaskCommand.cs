namespace Azure.ToDo.Message.Commands
{
    public class CreateTaskCommand
    {
        public Guid ItemId { get; set; }
        public string Title { get; set; }
    }
}
