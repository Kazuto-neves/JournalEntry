using FsCheck;
using JournalEntry.Domain.Dtos;
using JournalEntry.Domain.Enuns;
using Random = System.Random;

namespace JournalEntry.PropertyTests.Services
{
    public static class Types
    {
        public static int RandomNumber(int range)
        {
            Random rand = new();
            return (rand.Next(range));
        }
        public static Arbitrary<Guid> IdPropTest() => Arb.Default.Guid().Generator.ToArbitrary();
        public static Arbitrary<DateTime> DateTimePropTest() => Arb.Default.DateTime().Generator
            .Where(dt => dt > DateTime.UtcNow && dt <= DateTime.UtcNow.AddMonths(3)).ToArbitrary();

        public static Arbitrary<DateTimeOffset> DateTimeOfSetPropTest() => Arb.Default.DateTimeOffset().Generator
            .Where(dt => dt == DateTimeOffset.UtcNow).ToArbitrary();

        public static Arbitrary<Decimal> DecimalPropTest() => Arb.Default.Decimal().Generator
            .Where(dec => dec >= 0 && dec < 1001).ToArbitrary();

        public static TypeOperationJournalEntry RandomType(int range) => (TypeOperationJournalEntry)range;

        public static OperationJournalEntry RandomOperation(int range) => range == 0 ? OperationJournalEntry.Debit : OperationJournalEntry.Credit; 

        public static Arbitrary<EntryDto> EntryDtoPropTest() {
            OperationJournalEntry operationJournalEntry = RandomOperation(2);
            TypeOperationJournalEntry typeOperationJournalEntry = RandomType(1);
            return IdPropTest().Generator
            .Select(
                    _idPropTest => new EntryDto(
                    _idPropTest,
                    Arb.Default.DateTime().Generator.Where(dt => dt > DateTime.UtcNow && dt <= DateTime.UtcNow.AddMonths(3)),
                    Arb.Default.DateTimeOffset().Generator.Where(dt => dt >= DateTimeOffset.UtcNow),
                    Arb.Default.Decimal().Generator.Where(dec => dec is >= 0 and < 1001),
                    operationJournalEntry,
                    typeOperationJournalEntry
                    )
                ).ToArbitrary();
        }
    }
}
