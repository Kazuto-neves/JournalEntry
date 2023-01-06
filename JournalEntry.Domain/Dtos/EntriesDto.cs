﻿using JournalEntry.Domain.Entities;

namespace JournalEntry.Domain.Dtos
{
    public record EntriesDto(List<EntryDto> entries)
    {
        public bool Validate()
        {
            bool valido = false;

            foreach (var item in entries)
                valido=item.Validate();

            return valido;
        }

        public List<Entry> MapToEntry()
        {
            List<Entry> journalEntries = new List<Entry>();

            foreach (var item in entries)
                journalEntries.Add(item.CreateJournalEntry());

            return journalEntries;
        }
    }
}
