using E_Commerce.Common;
using E_Commerce.Domain.Product.Categories.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Infra.Data.Product.Categories.Mappings
{
    internal class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(GlobalUtils.FormatTableName(Constants.PREFIXPRODUCT, nameof(Category)));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnType("varchar")
                .HasMaxLength(120);

            builder.Property(x => x.Description)
                .HasColumnType("text");

            builder.HasIndex(builder => builder.Name)
                .IsUnique();

            builder.Property(x => x.Image)
                .HasColumnType("varbinary(max)");
        }
    }
}
