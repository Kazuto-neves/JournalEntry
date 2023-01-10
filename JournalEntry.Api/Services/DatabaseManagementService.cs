using JournalEntry.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace JournalEntry.Api.Services
{
    public static class DatabaseManagementService
    {

        public static void MigrationInitialisation(IApplicationBuilder app)
        {
            var configServiceScope = app.ApplicationServices.CreateScope().ServiceProvider.GetService<DbContexto>();

            if (configServiceScope is null)
                throw new Exception(nameof(MigrationInitialisation));
            
            configServiceScope.Database.Migrate();
        }
    }
}
