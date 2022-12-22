using JournalEntry.Domain.Entities;
using JournalEntry.Domain.Enuns;

namespace JournalEntry.UnitTests.Services
{
    public class Genereitor
    {
        internal int RandomNumber(int range)
        {
            Random rand = new();
            return (rand.Next(range));
        }
        public decimal RandomAmount(int range) => RandomNumber(range);
        public DateTime RandomDateTime(int dateAddEfective) => DateTime.UtcNow.AddDays(RandomNumber(dateAddEfective));
        public Entry CreateRandomJournalEntry(int range,int dateAddEfective)
        {
            return new()
            {
                Id = Guid.NewGuid(),
                EffectiveDate = RandomDateTime(dateAddEfective),
                Amount = RandomAmount(range),
                Operation = OperationJournalEntry.CREDIT,
                Type = TypeOperationJournalEntry.DIVIDENDS,
                CreateDate = DateTimeOffset.UtcNow,
            };
        }

    }
}
