using GirlCollection.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GirlCollection.Infrastructure.Data.EntityConfigurations
{
    public class ImageTypeEntityConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(e => e.Original)
                .IsRequired();
            builder.Property(e => e.Thumb)
                .IsRequired();

            builder.HasOne(e => e.Creator)
                .WithMany(e => e.Images)
                .HasForeignKey(e => e.CreatedBy);
            builder.HasOne(e => e.ImageType)
                .WithMany(e => e.Images)
                .HasForeignKey(e => e.Type);
            builder.HasOne(e => e.Information)
                .WithOne(e => e.Image)
                .HasForeignKey<Information>(e => e.ImageId);
            builder.HasMany(e => e.Favorites)
                .WithOne(e => e.Image)
                .HasForeignKey(e => e.ImageId);
            builder.HasMany(e => e.Votes)
                .WithOne(e => e.Image)
                .HasForeignKey(e => e.ImageId);
        }
    }
}
