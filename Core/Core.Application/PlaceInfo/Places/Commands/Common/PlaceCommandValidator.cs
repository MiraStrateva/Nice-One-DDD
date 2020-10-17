namespace Core.Application.PlaceInfo.Places.Commands.Common
{
    using Core.Domain.PlaceInfo.Models.Places;
    using Core.Domain.PlaceInfo.Repositories;
    using FluentValidation;
    using global::Common.Application;
    using global::Common.Domain.Models;
    using static global::Common.Domain.Models.ModelConstants.Common;

    public class PlaceCommandValidator<TCommand> : AbstractValidator<PlaceCommand<TCommand>>
        where TCommand : EntityCommand<int>
    {
        public PlaceCommandValidator(
            IPlaceDomainRepository placeRepository, 
            ICategoryDomainRepository categoryRepository,
            ICountryDomainRepository countryRepository)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            this.RuleFor(c => c.Name)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            this.RuleFor(c => c.Description)
                .MinimumLength(MinDescriptionLength)
                .MaximumLength(MaxDescriptionLength)
                .NotEmpty();

            //this.RuleFor(c => c.CategoryId)
            //    .MustAsync(async (category, token) => await categoryRepository
            //        .Get(category, token) != null)
            //    .WithMessage("{PropertyName} does not exist.");

            this.RuleFor(c => c.CountryId)
                .MustAsync(async (counrty, token) => await countryRepository
                    .Find(counrty, token) != null)
                .WithMessage("{PropertyName} does not exist.");

            this.RuleFor(c => c)
                .Must(cmd => Enumeration.HasValue<PlaceType>(cmd.Type.Value))
                .WithMessage("'PlaceType' is not valid.");

            this.RuleSet("Data", () =>
            {
                this.RuleFor(c => c)
                    .MustAsync(async (cmd, token) => await countryRepository
                    .Find(cmd.CountryId, cmd.CityId, token) != null)
                    .WithMessage("'City' does not exist.");
            });
        }
    }
}
