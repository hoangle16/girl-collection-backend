using GirlCollection.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GirlCollection.Infrastructure.Data.EntityConfigurations
{
    public class InformationTypeEntityConfiguration : IEntityTypeConfiguration<Information>
    {
        public void Configure(EntityTypeBuilder<Information> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.HasOne(e => e.Image)
                .WithOne(e => e.Information)
                .HasForeignKey<Information>(e => e.ImageId);
        }
    }
}
