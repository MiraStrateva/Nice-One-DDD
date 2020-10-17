namespace Core.Infrastructure.PlaceInfo.Configuration
{
    using Core.Domain.PlaceInfo.Models.Categories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static Common.Domain.Models.ModelConstants.Common;

    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(MaxDescriptionLength);

            builder
                .Property(c => c.ImageUrl)
                .IsRequired()
                .HasMaxLength(MaxUrlLength);
        }
    }
}
