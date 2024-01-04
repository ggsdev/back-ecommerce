using E_Commerce.Domain.Product.SubCategories.Entities;
using E_Commerce.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Infra.Data.Product.SubCategories.Mappings
{
    internal class SubCategoryMap : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.ToTable(GlobalUtils.FormatTableName(Constants.PREFIXPRODUCT, nameof(SubCategory)));

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

            builder.HasOne(x => x.Category)
                .WithMany(x => x.SubCategories)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
