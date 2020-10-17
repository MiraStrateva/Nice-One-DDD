namespace Core.Infrastructure.PlaceInfo
{
    using Common.Infrastructure.Persistence;
    using Core.Domain.PlaceInfo.Models.Categories;
    using Core.Domain.PlaceInfo.Models.Locations;
    using Core.Domain.PlaceInfo.Models.Places;
    using Microsoft.EntityFrameworkCore;

    internal interface IPlaceInfoDbContext : IDbContext
    {
        DbSet<Category> Categories { get; }

        DbSet<Country> Countries { get; }

        DbSet<City> Cities { get; }

        DbSet<Feedback> Feedbacks { get; }

        DbSet<Place> Places { get; }
    }
}
