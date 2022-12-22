using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalEntry.Domain.Enuns
{
    [Flags]
    public enum TypeOperationJournalEntry
    {
        DIVIDENDS = 1,
        EXPENSES = 2,
        ASSETS = 4,
        LIABILITIES = 8,
        OWNERS_EQUITY = 16,
        REVENUE = 32
    }
}
