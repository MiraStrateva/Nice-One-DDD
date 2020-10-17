namespace Core.Infrastructure.PlaceInfo.Configuration
{
    using Core.Domain.PlaceInfo.Models.Places;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static Common.Domain.Models.ModelConstants.Common;

    internal class PlaceConfiguration : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder.Property(p => p.Description)
                .HasMaxLength(MaxDescriptionLength);
        }
    }
}
