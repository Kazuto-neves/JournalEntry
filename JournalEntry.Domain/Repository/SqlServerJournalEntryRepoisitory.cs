using JournalEntry.Domain.Entities;
using JournalEntry.Domain.Interfaces;
using JournalEntry.Domain.Services;
using JournalEntry.Domain.Utilities;
using Microsoft.EntityFrameworkCore;

namespace JournalEntry.Domain.Repository
{
    public class SqlServerJournalEntryRepoisitory : IJournalEntriesRepository
    {
        private readonly DbContexto _db;
        public SqlServerJournalEntryRepoisitory(DbContexto db) => this._db = db;
        public async Task CreateJournalEntryAsync(Entry jEntry)
        {
            await _db.journalEntries.AddAsync(jEntry);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteJournalEntryAsync(Guid id)
        {
            var _result = await GetJournalEntryAsync(id);

            _db.journalEntries.Remove(_result);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Entry>> GetJournalEntriesAsync() => await _db.journalEntries.ToListAsync();

        public async Task<Entry> GetJournalEntryAsync(Guid id)
        {
            var _result = await _db.journalEntries.FindAsync(id);

            if (_result is null)
                throw ReturnException.nullReferenceException($"Não existe este journal entry ID: {id}");

            await Task.CompletedTask;
            return _result;
        }

        public async Task UpdateJournalEntryAsync(Entry jEntry)
        {
            var _result = await _db.journalEntries.FirstOrDefaultAsync(existingItem => existingItem.Id == jEntry.Id);

            if (_result is null)
                throw ReturnException.nullReferenceException($"Não existe este journal entry ID: {jEntry.Id}");
            else
            {
                _result.EffectiveDate = jEntry.EffectiveDate;
                _result.Amount = jEntry.Amount;
                _result.Type = jEntry.Type;
                _result.Operation = jEntry.Operation;
                _db.journalEntries.Update(_result);
                await _db.SaveChangesAsync();
            }
        }
    }
}
