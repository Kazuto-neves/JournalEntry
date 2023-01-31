using JournalEntry.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JournalEntry.Domain.Services
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> options) : base(options) { }
        public DbContexto() { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entry>().HasKey(x => x.Id);
            modelBuilder.Entity<Entry>().Property(x => x.Amount).HasColumnType("decimal(14,10)");
        }
        public DbSet<Entry> journalEntries { get; set; }
    }
}
