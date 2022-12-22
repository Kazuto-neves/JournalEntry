using FluentValidation.AspNetCore;
using JournalEntry.Api.Services;
using JournalEntry.Domain.Interfaces;
using JournalEntry.Domain.Repository;
using JournalEntry.Domain.Services;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace JournalEntry.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            var sqlServerSettings = Configuration.GetConnectionString("DbContexto");
            services.AddScoped<IJournalEntriesRepository, SqlServerJournalEntryRepoisitory>();
            services.AddDbContext<DbContexto>(options => options.UseSqlServer(sqlServerSettings, b => b.MigrationsAssembly("JournalEntry.Api")));
            services.AddScoped<DbContext, DbContexto>();
            
            services.AddControllers()
                .AddFluentValidation(x => x
                    .RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.Configure<JsonOptions>(c => c.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));
            services.Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(c => c.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            DatabaseManagementService.MigrationInitialisation(app);
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
