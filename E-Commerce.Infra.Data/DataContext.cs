using E_Commerce.Common;
using E_Commerce.Domain.ControlAccess.Infos.Entities;
using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.Infra.Data.ControlAccess.Infos.Mappings;
using E_Commerce.Infra.Data.ControlAccess.Users.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace E_Commerce.Infra.Data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Info> Infos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
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
        }

    }
}
