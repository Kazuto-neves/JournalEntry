using JournalEntry.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JournalEntry.Domain.Utilities
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Entry> journalEntries { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
