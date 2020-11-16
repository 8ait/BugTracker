﻿namespace Leonov.BugTracker.Domain.Database.SqlServer.Mapping
{
    using Leonov.BugTracker.Domain.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Маппинг для пользователя.
    /// </summary>
    public class UserMap : IEntityTypeConfiguration<User>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");
            builder.Property(user => user.Id).HasDefaultValueSql("newid()");
            builder.Property(auth => auth.Login).IsRequired().HasMaxLength(150);
            builder.HasIndex(user => user.Login).IsUnique();
            builder.Property(user => user.FirstName).IsRequired().HasMaxLength(150);
            builder.Property(user => user.Surname).IsRequired().HasMaxLength(150);
            builder.Property(auth => auth.HashPassword).IsRequired().HasMaxLength(128);
            builder.Property(auth => auth.Salt).IsRequired().HasMaxLength(128);
            builder.Property(auth => auth.CookieSession).HasMaxLength(128);

            builder.HasOne(user => user.UserType).WithMany().IsRequired();
        }
    }
}
