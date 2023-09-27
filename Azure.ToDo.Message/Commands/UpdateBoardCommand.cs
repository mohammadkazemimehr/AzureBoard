namespace Azure.ToDo.Message.Commands
{
    public class UpdateBoardCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
