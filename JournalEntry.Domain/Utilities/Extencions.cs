using JournalEntry.Domain.Dtos;
using JournalEntry.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalEntry.Domain.Utilities
{
    public static class Extencions
    {
        public static EntryDto AsDto(this Entry entry) => new(entry.Id, entry.EffectiveDate, entry.CreateDate, entry.Amount, entry.Operation, entry.Type);
    }
}
