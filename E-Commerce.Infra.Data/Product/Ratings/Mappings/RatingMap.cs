using E_Commerce.Domain.Product.Ratings.Entities;
using E_Commerce.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Infra.Data.Product.Ratings.Mappings
{
    public class RatingMap : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.ToTable(nameof(Rating), Constants.PREFIX_PRODUCT);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Comment)
                .HasColumnType("varchar")
                .HasMaxLength(200);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Ratings)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Item)
               .WithMany(x => x.Ratings)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
