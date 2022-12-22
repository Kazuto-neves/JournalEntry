using JournalEntry.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace JournalEntry.Api.Services
{
    public static class DatabaseManagementService
    {
        public static void MigrationInitialisation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                serviceScope.ServiceProvider.GetService<DbContexto>().Database.Migrate();
            }
        }
    }
}
