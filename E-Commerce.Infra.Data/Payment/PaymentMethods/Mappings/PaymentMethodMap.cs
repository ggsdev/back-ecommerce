using E_Commerce.Domain.Payment.PaymentMethods.Entities;
using E_Commerce.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Infra.Data.Payment.PaymentMethods.Mappings
{
    internal class PaymentMethodMap : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.ToTable(nameof(PaymentMethod), Constants.PREFIX_PAYMENT);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Description)
                .HasColumnType("varchar")
                .HasMaxLength(200);
        }
    }
}
