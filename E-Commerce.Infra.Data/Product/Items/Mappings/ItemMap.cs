using E_Commerce.Domain.Product.Items.Entities;
using E_Commerce.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Infra.Data.Product.Items.Mappings
{
    internal class ItemMap : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable(GlobalUtils.FormatTableName(Constants.PREFIXPRODUCT, nameof(Item)));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnType("varchar")
                .HasMaxLength(120);

            builder.Property(x => x.Description)
                .HasColumnType("varchar")
                .HasMaxLength(200);

            builder.Property(x => x.Price)
                .HasColumnType("decimal")
                .HasPrecision(Constants.PRICEPRECISION, Constants.PRICESCALE);

            builder.HasIndex(builder => builder.Name)
                .IsUnique();

            builder.HasOne(x => x.Stock)
                .WithOne(x => x.Item)
                .HasForeignKey<Item>(x => x.StockId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
