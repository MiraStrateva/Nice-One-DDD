namespace Core.Application.PlaceInfo.Locations.Commands.CreateCity
{
    using Core.Domain.PlaceInfo.Repositories;
    using FluentAssertions;
    using FluentValidation;
    using static Common.Domain.Models.ModelConstants.Common;

    public class CreateCityCommandValidator : AbstractValidator<CreateCityCommand>
    {
        public CreateCityCommandValidator(ICountryDomainRepository repository)
        {
            this.RuleFor(cmd => cmd.Name)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            this.RuleFor(cmd => cmd.CountryId)
                .MustAsync(async (countryId, token) => await repository
                    .Find(countryId, token) != null)
                .WithMessage("'{PropertyName}' does not exist.");
        }
    }
}
