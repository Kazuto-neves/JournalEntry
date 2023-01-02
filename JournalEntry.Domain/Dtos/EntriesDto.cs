using JournalEntry.Domain.Entities;

namespace JournalEntry.Domain.Dtos
{
    public record EntriesDto(List<EntryDto> entries)
    {
        public bool Validate()
        {
            bool valido = false;
            foreach (var item in entries)
            {
                valido=item.Validate();
            }
            return valido;
        }

        public List<Entry> MapToEntry()
        {
            List<Entry> journalEntries = new List<Entry>();
            foreach (var item in entries)
            {
                journalEntries.Add(item.CreateJournalEntry());
            }
            return journalEntries;
        }
    }
    /*public class EntriesDto
    {
        List<EntryDto> entriesDto = new List<EntryDto>();
        List<Entry> entries = new List<Entry>();
        EntryDto entryDto = new EntryDto();

        public void Add(Guid Id, DateTime EffectiveDate, DateTimeOffset CreateDate, decimal Amount, OperationJournalEntry Operation, TypeOperationJournalEntry Type)
        {
            entries.Add(new Entry()
            {
                Id = Id,
                CreateDate = CreateDate,
                EffectiveDate = EffectiveDate,
                Amount = Amount,
                Operation = Operation,
                Type = Type
            });
        }
        public bool Validate()
        {
            
            bool valido = false;
            foreach (var item in entriesDto)
            {
                if (valido) valido = item.Validate() ? true : false;
            }
            return valido;
        }
        public List<Entry> MapToEntry(Guid? id = null)
        {
            foreach (var item in entriesDto)
            {
                entries.Add(item.MapToEntry());
            }
            return entries;
        }
    }*/
}
