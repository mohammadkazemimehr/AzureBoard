namespace Azure.ToDo.Message.Commands
{
    public class CreateColumnCommand
    {
        public Guid BoardId { get; set; }
        public string Title { get; set; }
        public int Limit { get; set; }
    }
}
