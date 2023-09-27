namespace Azure.ToDo.Repository.Implimation
{
    internal class ItemTaskRepository : Repository<ItemTask>, IItemTaskRepository
    {
        private readonly DataContext _context;

        public ItemTaskRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public Guid Create(ColumnItem baseItem, string title)
        {
            var task = new ItemTask();
            task.Title = title;
            task.BaseItem = baseItem;
            
            _context.ItemTasks.Add(task);
            return task.Id;
        } 
    }
}
