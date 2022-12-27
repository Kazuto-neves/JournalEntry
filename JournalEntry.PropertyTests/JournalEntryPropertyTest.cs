using FsCheck;
using FsCheck.Xunit;
using JournalEntry.Api.Controllers;
using JournalEntry.Domain.Interfaces;
using JournalEntry.PropertyTests.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace JournalEntry.PropertyTests
{
    public class JournalEntryPropertyTest
    {
        private readonly Mock<IJournalEntriesRepository> repositoryStub = new Mock<IJournalEntriesRepository>();
        private readonly Mock<ILogger<JournalEntryController>> loggerStub = new();

        /*[Property(Arbitrary = new[] {typeof(Types)})]
        public Property CreateJournalEntriesAsync_WithItemToCreate_ReturnsCreatedJournalEntry()
        {

        }*/

        [Property]
        public Property Multiply_With_2_Is_The_Same_As_Adding_The_Same_Number(int x)
        {
            return (x * 2 == Add(x, x)).ToProperty().Collect(x);
        }

        private int Add(int x1, int x2) => x1 + x2;

        [Property(Arbitrary = new[] { typeof(Types) })]
        public Property contaDataTest(DateTime x)
        {
            return (x.Month - x.Month == dt(x, x)).ToProperty().Collect(x);
        }

        private int dt(DateTime x1, DateTime x2) => x1.Month - x2.Month;
    }
}