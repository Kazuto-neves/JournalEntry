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
                new Entry(){Id=Guid.NewGuid(),CreateDate=DateTimeOffset.UtcNow,EffectiveDate=generator.RandomDateTime(4),Operation=generator.RandomOperation(2),Type=generator.RandomType(5),Amount=generator.RandomAmount(30)},
                new Entry(){Id=Guid.NewGuid(),CreateDate=DateTimeOffset.UtcNow,EffectiveDate=generator.RandomDateTime(0),Operation=generator.RandomOperation(2),Type=generator.RandomType(5),Amount=generator.RandomAmount(80)},
                new Entry(){Id=Guid.NewGuid(),CreateDate=DateTimeOffset.UtcNow,EffectiveDate=generator.RandomDateTime(7),Operation=generator.RandomOperation(2),Type=generator.RandomType(5),Amount=generator.RandomAmount(50)}
            };

            repositoryStub.Setup(repo => repo.GetJournalEntriesAsync()).ReturnsAsync(allItems);

            var controller = new JournalEntryController(repositoryStub.Object, loggerStub.Object);

            var foundItems = await controller.GetJournalEntriesAsync();

            foundItems.Should().BeOfType<OkObjectResult>().Which.Value.Should().BeEquivalentTo(allItems.Select(c => c.AsDto()).ToList());
        }

        [Fact]
        public async Task CreateJournalEntriesAsync_WithItemToCreate_ReturnsCreatedJournalEntry()
        {
            var itemsToCreate = new EntriesDto(
                new List<EntryDto>(
                    new EntryDto[] {
                        generator.CreateTestEntryDtoJournalEntry(300, 5, OperationJournalEntry.Debit, TypeOperationJournalEntry.Dividends),
                        generator.CreateTestEntryDtoJournalEntry(700, 6, OperationJournalEntry.Credit, TypeOperationJournalEntry.Dividends),
                        generator.CreateTestEntryDtoJournalEntry(700, 5, OperationJournalEntry.Debit, TypeOperationJournalEntry.Dividends),
                        generator.CreateTestEntryDtoJournalEntry(300, 7, OperationJournalEntry.Credit, TypeOperationJournalEntry.Dividends),
                    }
                    )
                );

            var controller = new JournalEntryController(repositoryStub.Object, loggerStub.Object);

            var result = await controller.CreateJournalEntryAsync(itemsToCreate);

            result.Should().BeOfType<CreatedResult>();
        }

        [Fact]
        public async Task UpadateJournalEntryAsync_WithExistingJournalEntry_ReturnsNoContent()
        {
            var existingItem = generator.CreateTestJournalEntry(200, 4, OperationJournalEntry.Credit, TypeOperationJournalEntry.Dividends);
            var itemsResults = new[] {
                generator.CreateTestJournalEntry(300, 5, OperationJournalEntry.Debit, TypeOperationJournalEntry.Dividends),
                generator.CreateTestJournalEntry(700, 6, OperationJournalEntry.Debit, TypeOperationJournalEntry.Dividends),
                existingItem,
                generator.CreateTestJournalEntry(700, 6, OperationJournalEntry.Credit, TypeOperationJournalEntry.Dividends),
            };
            repositoryStub.Setup(repo => repo.GetJournalEntriesAsync()).ReturnsAsync(itemsResults);
            repositoryStub.Setup(repo => repo.GetJournalEntryAsync(It.IsAny<Guid>())).ReturnsAsync(existingItem);

            var itemToUpdate = new EntryDto(
                    existingItem.Id,
                    generator.RandomDateTime(7),
                    existingItem.CreateDate,
                    existingItem.Amount += 100,
                    existingItem.Operation,
                    existingItem.Type
                );

            var controller = new JournalEntryController(repositoryStub.Object, loggerStub.Object);

            var result = await controller.UpdateJournalEntryAsync(existingItem.Id, itemToUpdate);

            result.Should().BeOfType<OkObjectResult>();
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

        [Fact]
        public async Task CreateJournalEntriesAsync_WithItemToCreate_ReturnsBadRequest()
        {
            var itemsToCreate = new EntriesDto(
                new List<EntryDto>(
                    new EntryDto[] {
                        generator.CreateTestEntryDtoJournalEntry(300, 5, OperationJournalEntry.Debit, TypeOperationJournalEntry.Dividends),
                        generator.CreateTestEntryDtoJournalEntry(800, 6, OperationJournalEntry.Credit, TypeOperationJournalEntry.Dividends),
                        generator.CreateTestEntryDtoJournalEntry(700, 5, OperationJournalEntry.Debit, TypeOperationJournalEntry.Revenue),
                        generator.CreateTestEntryDtoJournalEntry(300, 7, OperationJournalEntry.Credit, TypeOperationJournalEntry.Dividends),
                    }
                    )
                );

            var controller = new JournalEntryController(repositoryStub.Object, loggerStub.Object);

            var result = await controller.CreateJournalEntryAsync(itemsToCreate);

            result.Should().BeOfType<BadRequestResult>();
        }

        [Fact]
        public async Task UpadateJournalEntryAsync_WithExistingJournalEntry_ReturnsBadRequest()
        {
            var existingItem = generator.CreateTestJournalEntry(200, 4, OperationJournalEntry.Credit, TypeOperationJournalEntry.Dividends);
            var itemsResults = new[] {
                generator.CreateTestJournalEntry(300, 5, OperationJournalEntry.Debit, TypeOperationJournalEntry.Dividends),
                generator.CreateTestJournalEntry(700, 6, OperationJournalEntry.Debit, TypeOperationJournalEntry.Dividends),
                existingItem,
                generator.CreateTestJournalEntry(700, 6, OperationJournalEntry.Credit, TypeOperationJournalEntry.Dividends),
            };
            repositoryStub.Setup(repo => repo.GetJournalEntriesAsync()).ReturnsAsync(itemsResults);
            repositoryStub.Setup(repo => repo.GetJournalEntryAsync(It.IsAny<Guid>())).ReturnsAsync(existingItem);

            var itemToUpdate = new EntryDto(
                    existingItem.Id,
                    generator.RandomDateTime(7),
                    existingItem.CreateDate,
                    existingItem.Amount += 100,
                    existingItem.Operation,
                    existingItem.Type
                );

            var controller = new JournalEntryController(repositoryStub.Object, loggerStub.Object);

            var result = await controller.UpdateJournalEntryAsync(Guid.NewGuid(), itemToUpdate);

            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task DeleteJournalEntryAsync_WithExistingJournalEntry_ReturnsNotFound()
        {
            var existingItem = generator.CreateRandomJournalEntry(1000, 4);
            repositoryStub.Setup(repo => repo.GetJournalEntryAsync(It.IsAny<Guid>()))
                .ReturnsAsync(existingItem);

            var controller = new JournalEntryController(repositoryStub.Object, loggerStub.Object);

            var result = await controller.DeleteJournalEntryAsync(Guid.NewGuid());

            result.Should().BeOfType<NotFoundResult>();
        }
    }
}