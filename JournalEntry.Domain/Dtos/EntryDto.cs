using JournalEntry.Domain.Entities;
using JournalEntry.Domain.Enuns;
using JournalEntry.Domain.Services;

namespace JournalEntry.Domain.Dtos
{
    public record EntryDto(Guid Id, DateTime EffectiveDate, DateTimeOffset CreateDate, decimal Amount, OperationJournalEntry Operation, TypeOperationJournalEntry Type)
    {
        public bool Validate()
        {
            var validator = new EntryDtoValidator();
            var validationResults = validator.Validate(this);
            if (!validationResults.IsValid)
                foreach (var failure in validationResults.Errors) Console.WriteLine("Propety" + failure.PropertyName + "Erro: " + failure.ErrorMessage);
            return validationResults.IsValid;
        }

        public Entry MapToEntry(Guid? id = null)
        {
            return new Entry()
            {
                Id = id is null ? Id : (Guid)id,
                CreateDate = CreateDate,
                EffectiveDate = EffectiveDate,
                Amount = Amount,
                Operation = Operation,
                Type = Type
            };
        }
    }
}
