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
    public class VoteTypeEntityConfiguration : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(e => e.Value)
                .IsRequired();

            builder.HasOne(e => e.User)
                .WithMany(e => e.Votes)
                .HasForeignKey(e => e.UserId);
            builder.HasOne(e => e.Image)
                .WithMany(e => e.Votes)
                .HasForeignKey(e => e.ImageId);
        }
    }
}
