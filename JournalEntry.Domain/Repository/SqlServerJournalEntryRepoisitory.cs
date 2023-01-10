using JournalEntry.Domain.Entities;
using JournalEntry.Domain.Interfaces;
using JournalEntry.Domain.Services;
using JournalEntry.Domain.Utilities;
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
            var _result = await GetJournalEntryAsync(id);

            db.journalEntries.Remove(_result);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Entry>> GetJournalEntriesAsync() => await db.journalEntries.ToListAsync();

        public async Task<Entry> GetJournalEntryAsync(Guid id)
        {
            var _result = await db.journalEntries.FindAsync(id);

            if (_result is null)
                throw ReturnException.nullException($"Não existe este journal entry ID: {id}");

            await Task.CompletedTask;
            return _result;
        }

        public async Task UpdateJournalEntryAsync(Entry jEntry)
        {
            var _result = await db.journalEntries.FirstOrDefaultAsync(existingItem => existingItem.Id == jEntry.Id);

            if (_result is null)
                throw ReturnException.nullException($"Não existe este journal entry ID: {jEntry.Id}");
            else
            {
                _result.EffectiveDate = jEntry.EffectiveDate;
                _result.Amount = jEntry.Amount;
                _result.Type = jEntry.Type;
                _result.Operation = jEntry.Operation;
                db.journalEntries.Update(_result);
                await db.SaveChangesAsync();
            }
        }
    }
}
