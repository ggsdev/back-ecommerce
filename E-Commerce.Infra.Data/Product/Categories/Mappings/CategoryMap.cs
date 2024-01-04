using E_Commerce.Domain.Product.Categories.Entities;
using E_Commerce.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Infra.Data.Product.Categories.Mappings
{
    internal class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(nameof(Category), Constants.PREFIX_PRODUCT);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnType("varchar")
                .HasMaxLength(120);

            builder.Property(x => x.Description)
                .HasColumnType("varchar")
                .HasMaxLength(200);

            builder.HasIndex(builder => builder.Name)
                .IsUnique();

            builder.Property(x => x.Image)
                .HasColumnType("varbinary(max)");
        }
    }
}
