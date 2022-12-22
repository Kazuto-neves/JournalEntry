using Castle.Components.DictionaryAdapter.Xml;
using FsCheck;
using JournalEntry.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalEntry.PropertyTests.Services
{
    public class Types
    {
        public static Arbitrary<Guid> IdPropTest() => Arb.Default.Guid().Generator.ToArbitrary();

       /* public static Arbitrary<EntryDto> EntryDtoPropTest() =>
            IdPropTest().Generator
            .Select(_idPropTest => new EntryDto(
                _idPropTest,
                Arb.Default.DateTime().Generator.ToArbitrary(),
                Arb.Default.DateTimeOffset().Generator.ToArbitrary(),
                Arb.Default.Decimal().Generator.ToArbitrary(),
                Arb.Default.String().Generator.ToArbitrary(),
                Arb.Default.String().Generator.ToArbitrary()
                ));*/

    }
}
