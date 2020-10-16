namespace Core.Application.PlaceInfo.Locations.Commands.CreateCountry
{
    using FluentValidation;
    using static Common.Domain.Models.ModelConstants.Common;

    public class CreateCounytyCommandValidator : AbstractValidator<CreateCountryCommand>
    {
        public CreateCounytyCommandValidator()
        {
            this.RuleFor(u => u.Name)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();
        }
    }
}
