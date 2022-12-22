using JournalEntry.Domain.Dtos;
using JournalEntry.Domain.Interfaces;
using JournalEntry.Domain.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace JournalEntry.Api.Controllers
{
    [Route("api/v1/journal-entries")]
    [ApiController]
    public class JournalEntryController : ControllerBase
    {
        private readonly IJournalEntriesRepository repository;

        private readonly ILogger<JournalEntryController> logger;
        public JournalEntryController(IJournalEntriesRepository repository, ILogger<JournalEntryController> logger)
        {
            this.repository = repository;

            this.logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateJournalEntryAsync(EntryDto entryDto)
        {
            if (!entryDto.Validate()) return BadRequest();

            await repository.CreateJournalEntryAsync(entryDto.MapToEntry());

            return Accepted();
        }

        [HttpGet]
        public async Task<IActionResult> GetJournalEntriesAsync(DateTime? effectiveDate = null)
        {
            var entries = await repository.GetJournalEntriesAsync();

            if (effectiveDate is not null) entries = entries.Where(entry => entry.EffectiveDate.Equals(effectiveDate));

            return Ok(entries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJournalEntryAsync(Guid id)
        {
            var jEntry = await repository.GetJournalEntryAsync(id);

            return (jEntry is null ? NotFound() : Ok(jEntry.AsDto()));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJournalEntryAsync(Guid id, EntryDto entryDto)
        {
            var existingJEntry = await repository.GetJournalEntryAsync(id);

            if (existingJEntry is null) return NotFound();

            if (!entryDto.Validate()) return BadRequest();

            await repository.UpdateJournalEntryAsync(entryDto.MapToEntry(id));

            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJournalEntryAsync(Guid id)
        {
            var existingJEntry = await repository.GetJournalEntryAsync(id);

            if (existingJEntry is null) return NotFound();

            await repository.DeleteJournalEntryAsync(id);

            return NoContent();
        }
    }
}
