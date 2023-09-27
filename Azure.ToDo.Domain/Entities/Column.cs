namespace Azure.ToDo.Domain.Entities
{
    public class Column : BaseEntity
    {
        public Column()
        {
            Items = new List<ColumnItem>();
        }
        public Column(string title)
        {
            Title = title;
            Limit = 5;
            Items = new List<ColumnItem>();
        }
        public string Title { get; set; }
        public int Limit { get; set; }
        public List<ColumnItem> Items { get; set; }
        public Board Bord { get; set; }
    }
}
