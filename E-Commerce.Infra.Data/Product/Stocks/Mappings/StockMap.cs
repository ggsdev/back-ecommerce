using E_Commerce.Shared;
using E_Commerce.Domain.Product.Stocks.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Infra.Data.Product.Stocks.Mappings
{
    internal class StockMap : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable(GlobalUtils.FormatTableName(Constants.PREFIXPRODUCT, nameof(Stock)));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
