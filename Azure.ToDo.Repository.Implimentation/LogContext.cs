using Azure.ToDo.Domain.LogEntities;
using Microsoft.EntityFrameworkCore;

namespace Azure.ToDo.Repository.Implimentation
{
    public class LogContext : DbContext
    {
        public DbSet<ExceptionLog> ExceptionLogs { get; set; }

        public LogContext(DbContextOptions<LogContext> options)
            : base(options) { }
    }
}
