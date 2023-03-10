using JournalEntry.Domain.Dtos;
using JournalEntry.Domain.Entities;
using JournalEntry.Domain.Enuns;

namespace JournalEntry.UnitTests.Services
{
    public class Generator
    {
        internal int RandomNumber(int range)
        {
            Random rand = new();
            return (rand.Next(range));
        }

        public decimal RandomAmount(int range) => RandomNumber(range);

        public DateTime RandomDateTime(int dateAddEfective) => DateTime.UtcNow.AddDays(RandomNumber(dateAddEfective));

        public TypeOperationJournalEntry RandomType(int range) => (TypeOperationJournalEntry)range;

        public OperationJournalEntry RandomOperation(int range) => range == 0 ? OperationJournalEntry.Debit : OperationJournalEntry.Credit;

        internal decimal amountsOfCasesGenerated(decimal amount, int? amountError = null) => amountError is null ? amount : amountError == 1 ? amount * -1 : RandomAmount((int)amountError);

        public Entry CreateRandomJournalEntry(int range, int dateAddEfective)
        {
            return new()
            {
                Id = Guid.NewGuid(),
                EffectiveDate = RandomDateTime(dateAddEfective),
                Amount = RandomAmount(range),
                Operation = RandomOperation(2),
                Type = RandomType(5),
                CreateDate = DateTimeOffset.UtcNow,
            };
        }

        public Object CreateTestEntry(int op, decimal amount, int dateAddEfective, OperationJournalEntry operation, TypeOperationJournalEntry type, int? amountError = null) =>
            op == 1 ? CreateTestJournalEntry(amount, dateAddEfective, operation, type, amountError) : CreateTestEntryDtoJournalEntry(amount, dateAddEfective, operation, type, amountError);


        public Entry CreateTestJournalEntry(decimal amount, int dateAddEfective, OperationJournalEntry operation, TypeOperationJournalEntry type, int? amountError = null)
        {
            OperationJournalEntry operationJournalEntry = operation;
            TypeOperationJournalEntry typeOperationJournal = type;
            return new()
            {
                Id = Guid.NewGuid(),
                EffectiveDate = RandomDateTime(dateAddEfective),
                Amount = amountsOfCasesGenerated(amount,amountError),
                Operation = operationJournalEntry,
                Type = typeOperationJournal,
                CreateDate = DateTimeOffset.UtcNow,
            };
        }

        public EntryDto CreateTestEntryDtoJournalEntry(decimal amount, int dateAddEfective, OperationJournalEntry operation, TypeOperationJournalEntry type, int? amountError = null)
        {
            OperationJournalEntry operationJournalEntry = operation;
            TypeOperationJournalEntry typeOperationJournal = type;
            return new EntryDto(
                Guid.NewGuid(),
                RandomDateTime(dateAddEfective),
                DateTimeOffset.UtcNow,
                amountsOfCasesGenerated(amount, amountError),
                operationJournalEntry,
                typeOperationJournal
                );
        }

        public Object CreateTestEntryNull(int Op)
        {
            object Return;
            if (Op == 1)
                Return = CreateTestJournalEntryNull();
            else
                Return = CreateTestJournalEntryDtoNull();

            return Return;
        }
        public Entry CreateTestJournalEntryNull()
        {
            Entry? entry = null;
            return entry;
        }

        public EntryDto CreateTestJournalEntryDtoNull()
        {
            EntryDto? entry = null;
            return entry;
        }

    }
}
