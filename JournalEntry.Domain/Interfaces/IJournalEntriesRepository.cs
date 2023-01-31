using JournalEntry.Domain.Entities;

namespace JournalEntry.Domain.Interfaces
{
    public interface IJournalEntriesRepository
    {
        Task<IEnumerable<Entry>> GetJournalEntriesAsync();
        Task<Entry> GetJournalEntryAsync(Guid id);
        Task CreateJournalEntryAsync(Entry jEntry);
        Task UpdateJournalEntryAsync(Entry jEntry);
        Task DeleteJournalEntryAsync(Guid id);
    }
}
