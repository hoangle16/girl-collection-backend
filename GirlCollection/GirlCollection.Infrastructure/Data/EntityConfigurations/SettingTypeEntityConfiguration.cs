using GirlCollection.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GirlCollection.Infrastructure.Data.EntityConfigurations
{
    public class SettingTypeEntityConfiguration : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(e => e.Name)
                .HasMaxLength(64)
                .IsRequired();

            builder.HasMany(e => e.UserSettings)
                .WithOne(e => e.Setting)
                .HasForeignKey(e => e.SettingId);
            builder.HasMany(e => e.SystemSettings)
                .WithOne(e => e.Setting)
                .HasForeignKey(e => e.SettingId);
        }
    }
}
