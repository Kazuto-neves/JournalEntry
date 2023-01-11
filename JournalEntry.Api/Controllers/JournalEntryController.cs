using JournalEntry.Domain.Dtos;
using JournalEntry.Domain.Interfaces;
using JournalEntry.Domain.Services;
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
        public async Task<IActionResult> CreateJournalEntryAsync(EntriesDto entriesDto)
        {
            var entries = await repository.GetJournalEntriesAsync();

            if (!entriesDto.Validate()) return BadRequest();

            if (!EntryValidatorAddAmount.Validador(entries, entriesDto.MapToEntry())) return BadRequest();

            foreach (var item in entriesDto.MapToEntry())
                await repository.CreateJournalEntryAsync(item);

            return Created(nameof(GetJournalEntriesAsync), entriesDto);
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
            var entries = await repository.GetJournalEntriesAsync();

            var existingJEntry = await repository.GetJournalEntryAsync(id);

            if (existingJEntry is null) return NotFound();

            if (!entryDto.Validate()) return BadRequest();

            if(!EntryValidatorAddAmount.Validador(entries, entryDto.journalEntryManipulate(existingJEntry))) return BadRequest();

            await repository.UpdateJournalEntryAsync(entryDto.journalEntryManipulate(existingJEntry));

            return Ok(existingJEntry.AsDto());
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
