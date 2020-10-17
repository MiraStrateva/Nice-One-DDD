namespace Core.Infrastructure.PlaceInfo.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static Common.Domain.Models.ModelConstants.Common;
    using Core.Domain.PlaceInfo.Models.Places;

    internal class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Text)
                .HasMaxLength(MaxDescriptionLength);

            builder.Property(f => f.Rating)
                .IsRequired();
        }
    }
}
