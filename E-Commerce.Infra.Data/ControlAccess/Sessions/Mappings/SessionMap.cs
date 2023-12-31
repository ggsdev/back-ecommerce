﻿using E_Commerce.Domain.ControlAccess.Sessions.Entities;
using E_Commerce.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Infra.Data.ControlAccess.Sessions.Mappings
{
    internal class SessionMap : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.ToTable(nameof(Session), Constants.PREFIX_CONTROL_ACCESS);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Token)
                .HasColumnType("varchar")
                .HasMaxLength(400);

            builder.Property(x => x.ExpirationDate);

            builder.Property(x => x.IsActive);

            builder.HasOne(x => x.User)
                .WithOne(x => x.Session)
                .HasForeignKey<Session>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
