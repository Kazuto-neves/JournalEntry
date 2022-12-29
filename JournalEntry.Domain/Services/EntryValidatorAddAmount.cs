using JournalEntry.Domain.Entities;
using JournalEntry.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalEntry.Domain.Services
{
    public static class EntryValidatorAddAmount
    {
        public static bool Validator(IEnumerable<Entry> entries, Entry entry)
        {
            decimal amount = 0;
            foreach (Entry e in entries)
            {
                if (e.Id != entry.Id)
                {
                    if (e.Type.Equals(TypeOperationJournalEntry.Dividends) || e.Type.Equals(TypeOperationJournalEntry.Expenses) || e.Type.Equals(TypeOperationJournalEntry.Assets))
                        amount = e.Operation.Equals(OperationJournalEntry.Debit) ? amount + e.Amount : amount - e.Amount;
                    else
                        amount = e.Operation.Equals(OperationJournalEntry.Debit) ? amount - e.Amount : amount + e.Amount;
                }
            }

            if (entry.Type.Equals(TypeOperationJournalEntry.Dividends) || entry.Type.Equals(TypeOperationJournalEntry.Expenses) || entry.Type.Equals(TypeOperationJournalEntry.Assets))
                amount = entry.Operation.Equals(OperationJournalEntry.Debit) ? amount + entry.Amount : amount - entry.Amount;
            else
                amount = entry.Operation.Equals(OperationJournalEntry.Debit) ? amount - entry.Amount : amount + entry.Amount;

            return (amount == 0 ? true : false);
        }
    }
}
