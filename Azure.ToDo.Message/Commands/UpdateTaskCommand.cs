namespace Azure.ToDo.Message.Commands
{
    public class UpdateTaskCommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
