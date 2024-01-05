using E_Commerce.Domain.ControlAccess.Infos.Entities;
using E_Commerce.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Infra.Data.ControlAccess.Infos.Mappings
{
    internal class InfoMap : IEntityTypeConfiguration<Info>
    {
        public void Configure(EntityTypeBuilder<Info> builder)
        {
            builder.ToTable(nameof(Info), Constants.PREFIX_CONTROL_ACCESS);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Cellphone)
                .HasColumnType("varchar")
                .HasMaxLength(11);

            builder.Property(x => x.Email)
                .HasColumnType("varchar")
                .HasMaxLength(120);

            builder.HasOne(x => x.Address)
                .WithOne()
                .HasForeignKey<Info>(x => x.AddressId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(builder => builder.Email)
                .IsUnique();

            builder.HasIndex(builder => builder.Cellphone)
                .IsUnique();
        }
    }
}
