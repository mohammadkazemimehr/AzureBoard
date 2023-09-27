using Azure.ToDo.Infrastructure.Enums;

namespace Azure.ToDo.Repository.Implimation
{
    public class ColumnItemRepository : Repository<ColumnItem> , IColumnItemRepository
    {

        private readonly DataContext _context;

        public ColumnItemRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public Guid Create(Column firstColumn,string title, ItemType type, string description)
        {
            var columnItem = new ColumnItem
            {
                Title = title,
                Type = type,
                Description = description,
                Column = firstColumn

            };

            firstColumn.Items.Add(columnItem);

            _context.ColumnItems.Add(columnItem);
            return columnItem.Id;
        }
    }
}
