using JournalEntry.Domain.Entities;

namespace JournalEntry.Domain.Dtos
{
    public record EntriesDto(List<EntryDto> entries)
    {
        public bool Validate() => entries.All(x => x.Validate());

        public List<Entry> MapToEntry()
        {
            List<Entry> journalEntries = new List<Entry>();

            foreach (var item in entries)
                journalEntries.Add(item.journalEntryManipulate());

            return journalEntries;
        }
    }
}
