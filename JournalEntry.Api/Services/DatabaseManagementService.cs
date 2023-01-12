using JournalEntry.Domain.Services;
using JournalEntry.Domain.Utilities;
using Microsoft.EntityFrameworkCore;

namespace JournalEntry.Api.Services
{
    public static class DatabaseManagementService
    {

        public static void MigrationInitialisation(IApplicationBuilder app)
        {
            var configServiceScope = app.ApplicationServices.CreateScope().ServiceProvider.GetService<DbContexto>();

            if (configServiceScope is null)
                throw ReturnException.getException("argumentNullException", nameof(configServiceScope));
                //throw ReturnException.argumentNullException(nameof(configServiceScope));
            
            configServiceScope.Database.Migrate();
        }
    }
}
