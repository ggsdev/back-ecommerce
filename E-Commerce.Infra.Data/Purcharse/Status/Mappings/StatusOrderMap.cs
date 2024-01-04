using E_Commerce.Domain.Purcharse.Status.Entities;
using E_Commerce.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Infra.Data.Purcharse.Status.Mappings
{
    internal class StatusOrderMap : IEntityTypeConfiguration<StatusOrder>
    {
        public void Configure(EntityTypeBuilder<StatusOrder> builder)
        {
            builder.ToTable(GlobalUtils.FormatTableName(Constants.PREFIXPURCHARSE, nameof(StatusOrder)));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
