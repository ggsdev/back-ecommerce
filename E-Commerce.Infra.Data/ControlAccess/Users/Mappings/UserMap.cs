using E_Commerce.Common;
using E_Commerce.Domain.ControlAccess.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Infra.Data.ControlAccess.Users.Mappings
{
    internal class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(GlobalUtils.FormatTableName(Constants.PREFIXCONTROLACCESS, nameof(User)));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnType("varchar")
                .HasMaxLength(120);

            builder.Property(x => x.Surname)
                .HasColumnType("varchar")
                .HasMaxLength(120);

            builder.Property(x => x.Age);

            builder.Property(x => x.IsAdmin);

            builder.Property(x => x.Password)
                .HasColumnType("varchar")
                .HasMaxLength(250);

            builder.HasOne(x => x.Info)
                .WithOne(i => i.User)
                .HasForeignKey<User>(x => x.InfoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}