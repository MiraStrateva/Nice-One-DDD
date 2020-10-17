namespace Core.Infrastructure.Statistics.Configuration
{
    using Domain.Statistics.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PlaceViewConfiguration : IEntityTypeConfiguration<PlaceView>
    {
        public void Configure(EntityTypeBuilder<PlaceView> builder)
            => builder.HasKey(pv => pv.Id);
    }
}
