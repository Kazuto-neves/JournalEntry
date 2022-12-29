using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalEntry.Domain.Enuns
{
    [Flags]
    public enum OperationJournalEntry
    {
        Credit = 1,
        Debit = 2
    }
}
