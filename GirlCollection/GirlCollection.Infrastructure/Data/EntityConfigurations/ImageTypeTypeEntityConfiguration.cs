using GirlCollection.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GirlCollection.Infrastructure.Data.EntityConfigurations
{
    public class ImageTypeTypeEntityConfiguration : IEntityTypeConfiguration<ImageType>
    {
        public void Configure(EntityTypeBuilder<ImageType> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.HasMany(e => e.Images)
                .WithOne(e => e.ImageType)
                .HasForeignKey(e => e.Type);
        }
    }
}
