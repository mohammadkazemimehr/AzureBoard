namespace Azure.ToDo.Message.Commands
{
    public class UpdateColumnCommand
    {
        public Guid Id { get; set; }
        public Guid BoardId { get; set; }
        public string Title { get; set; }
        public int Limit { get; set; }
    }
}
