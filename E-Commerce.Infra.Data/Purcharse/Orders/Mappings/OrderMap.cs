using E_Commerce.Domain.Purcharse.Orders.Entities;
using E_Commerce.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Infra.Data.Purcharse.Orders.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(GlobalUtils.FormatTableName(Constants.PREFIXPURCHARSE, nameof(Order)));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Description)
                .HasColumnType("varchar")
                .HasMaxLength(200);

            builder.Property(x => x.FreightCost)
                .HasColumnType("decimal")
                .HasPrecision(Constants.PRICEPRECISION, Constants.PRICESCALE);

            builder.Property(x => x.Total)
                .HasColumnType("decimal")
                .HasPrecision(Constants.PRICEPRECISION, Constants.PRICESCALE);

            builder.HasOne(x => x.Buyer)
                .WithMany(x => x.Orders)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.StatusOrder)
                .WithOne(x => x.Order)
                .HasForeignKey<Order>(x => x.StatusOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(builder => builder.PaymentMethod)
                .WithOne(x => x.Order)
                .HasForeignKey<Order>(x => x.PaymentMethodId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
