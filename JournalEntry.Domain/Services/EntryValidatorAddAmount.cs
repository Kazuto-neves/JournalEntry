using JournalEntry.Domain.Entities;
using JournalEntry.Domain.Enuns;

namespace JournalEntry.Domain.Services
{
    public static class EntryValidatorAddAmount
    {
        public static bool Validador(IEnumerable<Entry> entries,Object obj)
        {
            bool valido = false;
            valido = (obj.GetType() == typeof(Entry)) ? ValidatorUpdate(entries, (Entry)obj) : ValidatorCreate(entries, (List<Entry>)obj);
            return valido;
        }

        internal static bool ValidatorUpdate(IEnumerable<Entry> entries, Entry entry)
        {
            decimal amount = 0;
            foreach (Entry IEentry in entries)
            {
                if (IEentry.Id != entry.Id)
                {
                    if (IEentry.Type.Equals(TypeOperationJournalEntry.Dividends) || IEentry.Type.Equals(TypeOperationJournalEntry.Expenses) || IEentry.Type.Equals(TypeOperationJournalEntry.Assets))
                        amount = IEentry.Operation.Equals(OperationJournalEntry.Debit) ? amount + IEentry.Amount : amount - IEentry.Amount;
                    else
                        amount = IEentry.Operation.Equals(OperationJournalEntry.Debit) ? amount - IEentry.Amount : amount + IEentry.Amount;
                }
            }

            if (entry.Type.Equals(TypeOperationJournalEntry.Dividends) || entry.Type.Equals(TypeOperationJournalEntry.Expenses) || entry.Type.Equals(TypeOperationJournalEntry.Assets))
                amount = entry.Operation.Equals(OperationJournalEntry.Debit) ? amount + entry.Amount : amount - entry.Amount;
            else
                amount = entry.Operation.Equals(OperationJournalEntry.Debit) ? amount - entry.Amount : amount + entry.Amount;

            return (amount == 0 ? true : false);
        }

        internal static bool ValidatorCreate(IEnumerable<Entry> entries, List<Entry> journalEntries)
        {
            decimal amount = 0;
            foreach (var journalEntry in journalEntries)
            {
                foreach (Entry IEentry in entries)
                {
                    if (IEentry.Id != journalEntry.Id)
                    {
                        if (IEentry.Type.Equals(TypeOperationJournalEntry.Dividends) || IEentry.Type.Equals(TypeOperationJournalEntry.Expenses) || IEentry.Type.Equals(TypeOperationJournalEntry.Assets))
                            amount = journalEntry.Operation.Equals(OperationJournalEntry.Debit) ? amount + IEentry.Amount : amount - IEentry.Amount;
                        else
                            amount = IEentry.Operation.Equals(OperationJournalEntry.Debit) ? amount - IEentry.Amount : amount + IEentry.Amount;
                    }
                }

                if (journalEntry.Type.Equals(TypeOperationJournalEntry.Dividends) || journalEntry.Type.Equals(TypeOperationJournalEntry.Expenses) || journalEntry.Type.Equals(TypeOperationJournalEntry.Assets))
                    amount = journalEntry.Operation.Equals(OperationJournalEntry.Debit) ? amount + journalEntry.Amount : amount - journalEntry.Amount;
                else
                    amount = journalEntry.Operation.Equals(OperationJournalEntry.Debit) ? amount - journalEntry.Amount : amount + journalEntry.Amount;
            }

            return (amount == 0 ? true : false);
        }
    }
}
