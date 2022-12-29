using Azure;
using FluentValidation;
using JournalEntry.Domain.Entities;
using JournalEntry.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalEntry.Domain.Dtos
{
    public class EntriesDto
    {
        List<EntryDto> entriesDto = new List<EntryDto>();

        public bool Validate()
        {
            bool valido = true;
            foreach (var item in entriesDto)
            {
                if (valido) valido = item.Validate() ? true : false;
            }
            return valido;
        }
        public List<Entry> MapToEntry(Guid? id = null)
        {
            List<Entry> entries = new List<Entry>();
            foreach (var item in entriesDto)
            {
                entries.Add(item.MapToEntry());
            }
            return entries;
        }
    }
}
