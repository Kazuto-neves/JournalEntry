using FluentValidation;
using JournalEntry.Domain.Dtos;

namespace JournalEntry.Domain.Services
{
    public class EntryDtoValidator : AbstractValidator<EntryDto>
    {
        public EntryDtoValidator()
        {
            RuleFor(x => x.EffectiveDate)
                .NotEmpty().WithMessage("EffectiveDate is required");

            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("Amount is required")
                .GreaterThanOrEqualTo(0).WithMessage("Amount cannot less than 0");

            RuleFor(x => x.Operation)
                .NotEmpty().WithMessage("Operation is required")
                .IsInEnum().WithMessage("Typed operation does not exist");

            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Type is required")
                .IsInEnum().WithMessage("Operation type entered does not exist");
        }
    }
}
