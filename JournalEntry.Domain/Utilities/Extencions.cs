using JournalEntry.Domain.Dtos;
using JournalEntry.Domain.Entities;

namespace JournalEntry.Domain.Utilities
{
    public static class Extencions
    {
        public static EntryDto AsDto(this Entry entry) => new(entry.Id, entry.EffectiveDate, entry.CreateDate, entry.Amount, entry.Operation, entry.Type);
    }
}
