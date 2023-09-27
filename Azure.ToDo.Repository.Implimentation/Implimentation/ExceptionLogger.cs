using Azure.ToDo.Domain.LogEntities;

namespace Azure.ToDo.Repository.Implimentation.Implimentation
{
    public class ExceptionLogger : IExceptionLogger
    {
        private readonly LogContext _context;

        public ExceptionLogger(LogContext context)
        {
            _context = context;
        }

        public async Task SetLog(string exception, string stackTrace)
        {
            await _context.ExceptionLogs.AddAsync(new ExceptionLog(exception, stackTrace));
            await _context.SaveChangesAsync();
        }
    }
}
