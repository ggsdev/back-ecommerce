﻿using E_Commerce.Domain.ControlAccess.Infos.Entities;
using E_Commerce.Domain.ControlAccess.Sessions.Entities;
using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.Domain.Product.Categories.Entities;
using E_Commerce.Domain.Product.Images.Entites;
using E_Commerce.Domain.Product.Items.Entities;
using E_Commerce.Domain.Product.Stocks.Entities;
using E_Commerce.Domain.Purcharse.Orders.Entities;
using E_Commerce.Domain.Purcharse.Status.Entities;
using E_Commerce.Infra.Data.ControlAccess.Infos.Mappings;
using E_Commerce.Infra.Data.ControlAccess.Sessions.Mappings;
using E_Commerce.Infra.Data.ControlAccess.Users.Mappings;
using E_Commerce.Infra.Data.Payment.PaymentMethods.Mappings;
using E_Commerce.Infra.Data.Product.Categories.Mappings;
using E_Commerce.Infra.Data.Product.Images.Mappings;
using E_Commerce.Infra.Data.Product.Items.Mappings;
using E_Commerce.Infra.Data.Product.Ratings.Mappings;
using E_Commerce.Infra.Data.Product.Stocks.Mappings;
using E_Commerce.Infra.Data.Purcharse.Orders.Mappings;
using E_Commerce.Infra.Data.Purcharse.Status.Mappings;
using E_Commerce.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;

namespace E_Commerce.Infra.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Info> Infos { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<StatusOrder> StatusOrder { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.ConnectionString,
            x => x.MigrationsHistoryTable(Constants.MIGRATIONS_HISTORY_TABLE_NAME, Constants.PREFIX_SYSTEM));

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
            CreateProductMap(modelBuilder);
            CreatePurcharseMap(modelBuilder);
            CreatePaymentMap(modelBuilder);
        }

        private static void CreateAccessControlMap(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new AddressMap());
            modelBuilder.ApplyConfiguration(new InfoMap());
            modelBuilder.ApplyConfiguration(new SessionMap());
        }

        private static void CreateProductMap(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new ImageMap());
            modelBuilder.ApplyConfiguration(new ItemMap());
            modelBuilder.ApplyConfiguration(new StockMap());
            modelBuilder.ApplyConfiguration(new RatingMap());
        }

        private static void CreatePaymentMap(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PaymentMethodMap());
        }

        private static void CreatePurcharseMap(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new OrderItemsMap());
            modelBuilder.ApplyConfiguration(new StatusOrderMap());
        }

        private static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => builder.AddConsole());
    }
}
