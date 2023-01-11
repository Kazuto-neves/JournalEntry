using JournalEntry.Domain.Entities;
using JournalEntry.Domain.Enuns;
using JournalEntry.Domain.Services;

namespace JournalEntry.Domain.Dtos
{
    public record class EntryDto
    {
        public Guid Id { get; set; }

        public DateTime EffectiveDate { get; set; }

        public DateTimeOffset CreateDate { get; set; }

        public decimal Amount { get; set; }

        public OperationJournalEntry Operation { get; set; }

        public TypeOperationJournalEntry Type { get; set; }

        public EntryDto(Guid id,DateTime effectiveDate, DateTimeOffset createDate, decimal amount, OperationJournalEntry operation, TypeOperationJournalEntry type)
        {
            Id = id;
            EffectiveDate = effectiveDate;
            CreateDate = createDate;
            Amount = amount;
            Operation = operation;
            Type = type;
        }

        public bool Validate()
        {
            var validator = new EntryDtoValidator();

            var validationResults = validator.Validate(this);

            if (!validationResults.IsValid)
                foreach (var failure in validationResults.Errors) Console.WriteLine("Propety" + failure.PropertyName + "Erro: " + failure.ErrorMessage);

            return validationResults.IsValid;
        }

        public Entry journalEntryManipulate(Entry? entry = null) => (entry is null ? CreateJournalEntry() : UpdateJournalEntry(entry));

        internal Entry CreateJournalEntry()
        {
            return new Entry()
            {
                Id = Guid.NewGuid(),
                CreateDate = DateTimeOffset.UtcNow,
                EffectiveDate = EffectiveDate,
                Amount = Amount,
                Operation = Operation,
                Type = Type
            };
        }

        internal Entry UpdateJournalEntry(Entry entry)
        {
            Id = entry.Id;
            EffectiveDate = entry.EffectiveDate;
            CreateDate = entry.CreateDate;
            Amount = entry.Amount;
            Operation = entry.Operation;
            Type = entry.Type;
            return entry;
        }
    }
}
