using JournalEntry.Domain.Entities;
using JournalEntry.Domain.Interfaces;
using JournalEntry.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace JournalEntry.Domain.Repository
{
    public class SqlServerJournalEntryRepoisitory : IJournalEntriesRepository
    {
        private DbContexto db;
        public SqlServerJournalEntryRepoisitory(DbContexto db) => this.db = db;
        public async Task CreateJournalEntryAsync(Entry jEntry)
        {
            await db.journalEntries.AddAsync(jEntry);
            await db.SaveChangesAsync();
        }

        public async Task DeleteJournalEntryAsync(Guid id)
        {
            var filter = await db.journalEntries.FindAsync(id);
            db.journalEntries.Remove(filter);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Entry>> GetJournalEntriesAsync() => await db.journalEntries.ToListAsync();

        public async Task<Entry> GetJournalEntryAsync(Guid id) => await db.journalEntries.FindAsync(id);

        public async Task UpdateJournalEntryAsync(Entry jEntry)
        {
            var filter = await db.journalEntries.FirstOrDefaultAsync(existingItem => existingItem.Id == jEntry.Id);
            filter.EffectiveDate = jEntry.EffectiveDate;
            filter.Amount = jEntry.Amount;
            filter.Type = jEntry.Type;
            filter.Operation = jEntry.Operation;
            db.journalEntries.Update(filter);
            await db.SaveChangesAsync();
        }
    }
}
