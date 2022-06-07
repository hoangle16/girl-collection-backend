using GirlCollection.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GirlCollection.Infrastructure.Data.EntityConfigurations
{
    public class UserTypeEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(e => e.Name)
                .HasMaxLength(128)
                .IsRequired();
            builder.HasIndex(e => e.Email);
            builder.Property(e => e.Email)
                .IsRequired();
            builder.Property(e => e.Role)
                .IsRequired();

            builder.HasMany(e => e.Images)
                .WithOne(e => e.Creator)
                .HasForeignKey(e => e.CreatedBy);
            builder.HasMany(e => e.Favorites)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId);
            builder.HasMany(e => e.Votes)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId);
            builder.HasMany(e => e.UserSettings)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId);
        }
    }
}
