using JournalEntry.Domain.Enuns;
using System.ComponentModel.DataAnnotations;

namespace JournalEntry.Domain.Entities
{
    public class Entry
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public decimal Amount { get; set; }
        public OperationJournalEntry Operation { get; set; }
        public TypeOperationJournalEntry Type { get; set; }
    }
}
