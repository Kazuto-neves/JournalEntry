using Castle.Components.DictionaryAdapter.Xml;
using FsCheck;
using JournalEntry.Domain.Dtos;
using JournalEntry.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalEntry.PropertyTests.Services
{
    public class Types
    {
        public static Arbitrary<Int32> Number() => Arb.Default.Int32().Generator.ToArbitrary();
        public static Arbitrary<Guid> IdPropTest() => Arb.Default.Guid().Generator.ToArbitrary();
        public static Arbitrary<DateTime> DateTimePropTest() => Arb.Default.DateTime().Generator
            .Where(dt => dt > DateTime.UtcNow && dt <= DateTime.UtcNow.AddMonths(3)).ToArbitrary();

        public static Arbitrary<DateTimeOffset> DateTimeOfSetPropTest() => Arb.Default.DateTimeOffset().Generator
            .Where(dt => dt == DateTimeOffset.UtcNow).ToArbitrary();

        public static Arbitrary<Decimal> DecimalPropTest() => Arb.Default.Decimal().Generator
            .Where(dec => dec >= 0 && dec < 1001).ToArbitrary();

        /*public static Arbitrary<Object> OperationPropTest() => Arb.Default.Object<OperationJournalEntry>().Generator
            .Where(oprJE => oprJE == OperationJournalEntry.DEBIT || oprJE == OperationJournalEntry.CREDIT).ToArbitrary();

        public static Arbitrary<EntryDto> EntryDtoPropTest() =>
            IdPropTest().Generator
            .Select(
                    _idPropTest => new EntryDto(
                    _idPropTest,
                    Arb.Default.DateTime().Generator.Where(dt => dt > DateTime.UtcNow && dt <= DateTime.UtcNow.AddMonths(3)),
                    Arb.Default.DateTimeOffset().Generator.Where(dt => dt >= DateTimeOffset.UtcNow),
                    Arb.Default.Decimal().Generator.Where(dec => dec >= 0 && dec < 1001),
                    Arb.Default.
                    //Arb.Default.String().Generator
                    )
                ).ToArbitrary();*/
    }
}
