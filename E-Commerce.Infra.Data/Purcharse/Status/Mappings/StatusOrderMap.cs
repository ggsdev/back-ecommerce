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
            builder.ToTable(nameof(StatusOrder), Constants.PREFIX_PURCHARSE);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
