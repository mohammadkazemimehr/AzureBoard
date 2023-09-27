using Azure.ToDo.Repository.Implimentation;
using Microsoft.EntityFrameworkCore;

namespace Azure.ToDo.Base.Extentions
{
    public static class WebHostExtension
    {
        public static WebApplication Seed(this WebApplication host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                var databaseContext = serviceProvider.GetRequiredService<DataContext>();
                var logContext = serviceProvider.GetRequiredService<LogContext>();

                databaseContext.Database.Migrate();
                logContext.Database.Migrate();
            }

            return host;
        }
    }
}
