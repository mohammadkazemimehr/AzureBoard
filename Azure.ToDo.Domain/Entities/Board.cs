namespace Azure.ToDo.Domain.Entities
{
    public class Board : BaseEntity
    {
        public Board()
        {
            Columns = new List<Column>();
        }
        public User Owner { get; set; }

        public string Name { get; set; }
        public List<Column> Columns { get; set; }

    }
}
