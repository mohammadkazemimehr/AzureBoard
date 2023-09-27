namespace Azure.ToDo.Repository.Implimation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private IUserRepository _userRepository;
        private IBoardRepository _boardRepository;
        private IColumnRepository _columnRepository;
        private IColumnItemRepository _columnItemRepository;
        private IItemTaskRepository _itemTaskRepository;
        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository => _userRepository = _userRepository ?? new UserRepository(_context);
        public IBoardRepository BoardRepository => _boardRepository = _boardRepository ?? new BoardRepository(_context);
        public IColumnRepository ColumnRepository => _columnRepository = _columnRepository ?? new ColumnRepository(_context);
        public IColumnItemRepository ColumnItemRepository => _columnItemRepository = _columnItemRepository ?? new ColumnItemRepository(_context);
        public IItemTaskRepository ItemTaskRepository => _itemTaskRepository = _itemTaskRepository ?? new ItemTaskRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
