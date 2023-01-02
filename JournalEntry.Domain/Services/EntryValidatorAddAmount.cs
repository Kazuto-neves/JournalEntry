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

        public static bool ValidatorList(IEnumerable<Entry> entries, List<Entry> entry)
        {
            decimal amount = 0;
            foreach (var e in entry)
            {
                foreach (Entry e2 in entries)
                {
                    if (e2.Id != e2.Id)
                    {
                        if (e2.Type.Equals(TypeOperationJournalEntry.Dividends) || e2.Type.Equals(TypeOperationJournalEntry.Expenses) || e2.Type.Equals(TypeOperationJournalEntry.Assets))
                            amount = e2.Operation.Equals(OperationJournalEntry.Debit) ? amount + e2.Amount : amount - e2.Amount;
                        else
                            amount = e2.Operation.Equals(OperationJournalEntry.Debit) ? amount - e2.Amount : amount + e2.Amount;
                    }
                }

                if (e.Type.Equals(TypeOperationJournalEntry.Dividends) || e.Type.Equals(TypeOperationJournalEntry.Expenses) || e.Type.Equals(TypeOperationJournalEntry.Assets))
                    amount = e.Operation.Equals(OperationJournalEntry.Debit) ? amount + e.Amount : amount - e.Amount;
                else
                    amount = e.Operation.Equals(OperationJournalEntry.Debit) ? amount - e.Amount : amount + e.Amount;
            }

            return (amount == 0 ? true : false);
        }
    }
}
