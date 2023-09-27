using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Azure.ToDo.Repository.Implimentation
{
    public class DataContext : DbContext
    {
        public DbSet<Board> Bords { get; set; }
        public DbSet<Column> Columns { get; set; }
        public DbSet<ColumnItem> ColumnItems { get; set; }
        public DbSet<ItemTask> ItemTasks { get; set; }
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
