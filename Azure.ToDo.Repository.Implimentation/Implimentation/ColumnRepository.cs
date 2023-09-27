namespace Azure.ToDo.Repository.Implimation
{
    public class ColumnRepository : Repository<Column>, IColumnRepository
    {
        private readonly DataContext _context;

        public ColumnRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public Guid Create(Board board, string title, int limit)
        {
            var column = new Column()
            {
                Title = title,
                Limit = limit,
                Bord = board,
            };

            _context.Columns.Add(column);
            return column.Id;
        }
    }
}
