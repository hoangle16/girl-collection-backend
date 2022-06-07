using GirlCollection.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GirlCollection.Infrastructure.Data.EntityConfigurations
{
    public class SystemSettingTypeEntityConfiguration : IEntityTypeConfiguration<SystemSetting>
    {
        public void Configure(EntityTypeBuilder<SystemSetting> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(e => e.Value)
                .IsRequired();

            builder.HasOne(e => e.Setting)
                .WithMany(e => e.SystemSettings)
                .HasForeignKey(e => e.SettingId);
        }
    }
}
