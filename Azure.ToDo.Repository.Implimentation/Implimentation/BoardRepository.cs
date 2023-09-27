namespace Azure.ToDo.Repository.Implimation
{
    public class BoardRepository : Repository<Board>, IBoardRepository
    {

        private readonly DataContext _context;

        public BoardRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Guid> CreateBoard(string name,User user)
        {
            var bord = new Board()
            {
                Name = name,
                Owner = user
            };

            SetDefultColumn(bord);
            _context.Bords.Add(bord);
            return bord.Id;
        }

        private void SetDefultColumn(Board bord)
        {
            bord.Columns.Add(new Column("New"));
            bord.Columns.Add(new Column("Analyze"));
            bord.Columns.Add(new Column("Doing"));
            bord.Columns.Add(new Column("Develop"));
            bord.Columns.Add(new Column("Test"));
            bord.Columns.Add(new Column("Done"));
        }
    }
}
