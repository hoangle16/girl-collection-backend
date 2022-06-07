using GirlCollection.Domain.Entities;
using GirlCollection.Infrastructure.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GirlCollection.Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Information> Information { get; set; }
        public virtual DbSet<ImageType> ImageTypes { get; set; }
        public virtual DbSet<Favorite> Favorites { get; set; }
        public virtual DbSet<Vote> Votes { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<UserSetting> UserSettings { get; set; }
        public virtual DbSet<SystemSetting> SystemSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserTypeEntityConfiguration());
            builder.ApplyConfiguration(new ImageTypeEntityConfiguration());
            builder.ApplyConfiguration(new FavoriteTypeEntityConfiguration());
            builder.ApplyConfiguration(new ImageTypeTypeEntityConfiguration());
            builder.ApplyConfiguration(new InformationTypeEntityConfiguration());
            builder.ApplyConfiguration(new VoteTypeEntityConfiguration());
            builder.ApplyConfiguration(new SettingTypeEntityConfiguration());
            builder.ApplyConfiguration(new UserSettingTypeEntityConfiguration());
            builder.ApplyConfiguration(new SystemSettingTypeEntityConfiguration());
        }
        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified || x.State == EntityState.Deleted));

            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow;

                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CreatedAt = now;
                }
                ((BaseEntity)entity.Entity).UpdatedAt = now;
            }
        }
    }
}
