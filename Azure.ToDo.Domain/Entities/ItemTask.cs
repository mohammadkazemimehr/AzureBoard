namespace Azure.ToDo.Domain.Entities
{
    public class ItemTask : BaseEntity
    {
        public string Title { get; set; }
        public ColumnItem BaseItem { get; set; }
    }
}
