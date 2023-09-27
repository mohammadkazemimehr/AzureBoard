namespace Azure.ToDo.Message.Commands
{
    public class ChangeColumnCommand
    {
        public Guid Id { get; set; }
        public Guid ColumnId { get; set; }
    }
}
