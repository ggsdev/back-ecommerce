using E_Commerce.Domain.ControlAccess.Infos.Entities;
using E_Commerce.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Infra.Data.ControlAccess.Infos.Mappings
{
    internal class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable(nameof(Address), Constants.PREFIX_CONTROL_ACCESS);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Street)
                .HasColumnType("varchar")
                .HasMaxLength(250);

            builder.Property(x => x.Number)
                .HasColumnType("varchar")
                .HasMaxLength(10);

            builder.Property(x => x.Reference)
                .HasColumnType("varchar")
                .HasMaxLength(120);

            builder.Property(x => x.City)
                .HasColumnType("varchar")
                .HasMaxLength(120);

            builder.Property(x => x.Complement)
                .HasColumnType("varchar")
                .HasMaxLength(60);

            builder.Property(x => x.State)
                .HasColumnType("char")
                .HasMaxLength(2);

            builder.Property(x => x.ZipCode)
                .HasColumnType("char")
                .HasMaxLength(9);
        }
    }
}
