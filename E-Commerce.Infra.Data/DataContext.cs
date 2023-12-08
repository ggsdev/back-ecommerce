using E_Commerce.Common;
using E_Commerce.Domain.ControlAccess.Infos.Entities;
using E_Commerce.Domain.ControlAccess.Sessions.Entities;
using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.Infra.Data.ControlAccess.Infos.Mappings;
using E_Commerce.Infra.Data.ControlAccess.Sessions.Mappings;
using E_Commerce.Infra.Data.ControlAccess.Users.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;

namespace E_Commerce.Infra.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Info> Infos { get; set; }
        public DbSet<Session> Sessions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.ConnectionString);

            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }
        private void UpdateTimestamps()
        {
            var modifiedEntriesBaseModel = ChangeTracker.Entries<BaseEntity>()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in modifiedEntriesBaseModel)
            {
                if (entry.Entity is BaseEntity baseModel)
                {
                    baseModel.CreatedAt =
                        entry.State == EntityState.Added ?
                        DateTime.Now : baseModel.CreatedAt;

                    baseModel.UpdatedAt =
                        entry.State == EntityState.Modified ?
                        DateTime.Now : baseModel.UpdatedAt;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CreateAccessControlMap(modelBuilder);
        }

        private static void CreateAccessControlMap(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new AddressMap());
            modelBuilder.ApplyConfiguration(new InfoMap());
            modelBuilder.ApplyConfiguration(new SessionMap());
        }

        private static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => builder.AddConsole());
    }
}
