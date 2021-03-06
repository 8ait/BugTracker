﻿namespace Leonov.BugTracker.Domain.Database.SqlServer.Mapping
{
    using Leonov.BugTracker.Domain.Database.SqlServer.Mapping.Base;
    using Leonov.BugTracker.Domain.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Маппинг для типа сущности.
    /// </summary>
    public class UserTypeMap : BaseDictionaryMap<UserType>
    {
        /// <inheritdoc/>
        public override void Configure(EntityTypeBuilder<UserType> builder)
        {
            base.Configure(builder);
            builder.ToTable("user_type");

            builder.HasMany(x => x.Arms)
                .WithMany(x => x.UserTypes);
        }
    }
}
