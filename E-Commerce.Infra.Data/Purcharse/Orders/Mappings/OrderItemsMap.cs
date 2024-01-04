using E_Commerce.Domain.Purcharse.Orders.Entities;
using E_Commerce.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Infra.Data.Purcharse.Orders.Mappings
{
    internal class OrderItemsMap : IEntityTypeConfiguration<OrderItems>
    {
        public void Configure(EntityTypeBuilder<OrderItems> builder)
        {
            builder.ToTable(nameof(OrderItems), Constants.PREFIX_PURCHARSE);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Price)
                .HasColumnType("decimal")
                .HasPrecision(Constants.PRICE_PRECISION, Constants.PRICE_SCALE);

            builder.Property(x => x.Total)
            .HasColumnType("decimal")
            .HasPrecision(Constants.PRICE_PRECISION, Constants.PRICE_SCALE)
            .HasComputedColumnSql("[Quantity] * [Price]");

            builder.HasOne(x => x.Order)
                .WithMany(x => x.OrderProducts)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Item)
                .WithMany(x => x.OrderProducts)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
