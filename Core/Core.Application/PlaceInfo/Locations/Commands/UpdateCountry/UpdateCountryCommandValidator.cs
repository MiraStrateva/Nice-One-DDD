namespace Core.Application.PlaceInfo.Locations.Commands.UpdateCountry
{
    using Core.Domain.PlaceInfo.Repositories;
    using FluentAssertions;
    using FluentValidation;
    using static Common.Domain.Models.ModelConstants.Common;

    public class UpdateCountryCommandValidator : AbstractValidator<UpdateCountryCommand>
    {
        public UpdateCountryCommandValidator(ICountryDomainRepository repository)
        {
            this.RuleFor(cmd => cmd.Name)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            this.RuleFor(cmd => cmd.Id)
                .MustAsync(async (id, token) => await repository
                    .Find(id, token) != null)
                .WithMessage("'{PropertyName}' does not exist.");
        }
    }
}
