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
        Dividends = 1,
        Expenses = 2,
        Assets = 4,
        Liabilities = 8,
        OwnersEquity = 16,
        Revenue = 32
    }
}
