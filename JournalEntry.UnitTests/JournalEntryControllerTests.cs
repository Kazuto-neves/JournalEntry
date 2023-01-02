using JournalEntry.Api.Controllers;
using JournalEntry.Domain.Dtos;
using JournalEntry.Domain.Entities;
using JournalEntry.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using JournalEntry.Domain.Enuns;
using JournalEntry.Domain.Utilities;
using FluentAssertions;
using JournalEntry.UnitTests.Services;

namespace JournalEntry.UnitTests
{
    public class JournalEntryControllerTests
    {
        private readonly Mock<IJournalEntriesRepository> repositoryStub = new Mock<IJournalEntriesRepository>();
        private readonly Mock<ILogger<JournalEntryController>> loggerStub = new();
        private Generator generator = new Generator();

        [Fact]
        public async Task GetJournalEntryAsync_WithUnexistingJournalEntry_ReturnsNotFound()
        {
            var controller = new JournalEntryController(repositoryStub.Object, loggerStub.Object);

            var result = await controller.GetJournalEntryAsync(Guid.NewGuid());

            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task GetJournalEntryAsync_WithUnexistingJournalEntry_ReturnsExpextedJournalEntry()
        {
            var itemResult = generator.CreateRandomJournalEntry(1000, 4);
            var itemDtoExpected = itemResult.AsDto();
            repositoryStub.Setup(repo => repo.GetJournalEntryAsync(It.IsAny<Guid>())).ReturnsAsync(itemResult);

            var controller = new JournalEntryController(repositoryStub.Object, loggerStub.Object);

            var result = await controller.GetJournalEntryAsync(Guid.NewGuid());

            result.Should().BeOfType<OkObjectResult>().Which.Value
                .Should().BeOfType<EntryDto>().Which
                .Should().Match<EntryDto>(c => c.Id == itemDtoExpected.Id);
        }

        [Fact]
        public async Task GetJournalEntriesAsync_WithUnexistingJournalEntries_ReturnsAllJournalEntries()
        {
            var itemsResults = new[] { generator.CreateRandomJournalEntry(1000, 4), generator.CreateRandomJournalEntry(1000, 6), generator.CreateRandomJournalEntry(1000, 9) };

            repositoryStub.Setup(repo => repo.GetJournalEntriesAsync()).ReturnsAsync(itemsResults);

            var controller = new JournalEntryController(repositoryStub.Object, loggerStub.Object);

            var actualItems = await controller.GetJournalEntriesAsync();

            actualItems.Should().BeOfType<OkObjectResult>().Which.Value
                .Should().BeEquivalentTo(itemsResults.Select(c => c.AsDto()).ToList());
        }

        [Fact]
        public async Task GetJournalEntriesAsync_WithMatchingJournalEntries_ReturnsMathingJournalEntries()
        {
            var allItems = new[]
            {
                new Entry(){Id=Guid.NewGuid(),CreateDate=DateTimeOffset.UtcNow,EffectiveDate=generator.RandomDateTime(4),Operation=OperationJournalEntry.Debit,Type=TypeOperationJournalEntry.Revenue,Amount=generator.RandomAmount(30)},
                new Entry(){Id=Guid.NewGuid(),CreateDate=DateTimeOffset.UtcNow,EffectiveDate=generator.RandomDateTime(0),Operation=OperationJournalEntry.Debit,Type=TypeOperationJournalEntry.Revenue,Amount=generator.RandomAmount(80)},
                new Entry(){Id=Guid.NewGuid(),CreateDate=DateTimeOffset.UtcNow,EffectiveDate=generator.RandomDateTime(7),Operation=OperationJournalEntry.Debit,Type=TypeOperationJournalEntry.Revenue,Amount=generator.RandomAmount(50)}
            };

            repositoryStub.Setup(repo => repo.GetJournalEntriesAsync()).ReturnsAsync(allItems);

            var controller = new JournalEntryController(repositoryStub.Object, loggerStub.Object);

            var foundItems = await controller.GetJournalEntriesAsync();

            foundItems.Should().BeOfType<OkObjectResult>().Which.Value.Should().BeEquivalentTo(allItems.Select(c => c.AsDto()).ToList());
        }

        [Fact]
        public async Task CreateJournalEntriesAsync_WithItemToCreate_ReturnsCreatedJournalEntry()
        {
            var itemToCreate = new EntryDto(
                Guid.NewGuid(),
                DateTime.UtcNow,
                DateTimeOffset.UtcNow,
                generator.RandomAmount(1000),
                OperationJournalEntry.Credit,
                TypeOperationJournalEntry.Assets
                );

            var controller = new JournalEntryController(repositoryStub.Object, loggerStub.Object);

            var result = await controller.CreateJournalEntryAsync(itemToCreate);

            result.Should().BeOfType<AcceptedResult>();
        }

        [Fact]
        public async Task UpadateJournalEntryAsync_WithExistingJournalEntry_ReturnsNoContent()
        {
            var existingItem = generator.CreateRandomJournalEntry(1000, 2);
            repositoryStub.Setup(repo => repo.GetJournalEntryAsync(It.IsAny<Guid>()))
                .ReturnsAsync(existingItem);

            var itemId = existingItem.Id;
            var itemToUpdate = new EntryDto(
                    itemId,
                    DateTime.UtcNow,
                    DateTimeOffset.UtcNow,
                    existingItem.Amount += 2,
                    OperationJournalEntry.Credit,
                    TypeOperationJournalEntry.Assets
                );

            var controller = new JournalEntryController(repositoryStub.Object, loggerStub.Object);

            var result = await controller.UpdateJournalEntryAsync(itemId, itemToUpdate);

            result.Should().BeOfType<AcceptedResult>();
        }

        [Fact]
        public async Task DeleteJournalEntryAsync_WithExistingJournalEntry_ReturnsNoContent()
        {
            var existingItem = generator.CreateRandomJournalEntry(1000, 4);
            repositoryStub.Setup(repo => repo.GetJournalEntryAsync(It.IsAny<Guid>()))
                .ReturnsAsync(existingItem);

            var controller = new JournalEntryController(repositoryStub.Object, loggerStub.Object);

            var result = await controller.DeleteJournalEntryAsync(existingItem.Id);

            result.Should().BeOfType<NoContentResult>();
        }
    }
}