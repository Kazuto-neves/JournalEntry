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

        [Property(Arbitrary = new[] {typeof(Types)})]
        public Property CreateJournalEntriesAsync_WithItemToCreate_ReturnsCreatedJournalEntry()
        {

        }
    }
}