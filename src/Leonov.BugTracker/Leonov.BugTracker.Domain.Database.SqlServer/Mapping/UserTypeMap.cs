namespace Leonov.BugTracker.Domain.Database.SqlServer.Mapping
{
    using Leonov.BugTracker.Domain.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Маппинг для типа сущности.
    /// </summary>
    public class UserTypeMap : IEntityTypeConfiguration<UserType>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.ToTable("user_type");
            builder.Property(userType => userType.Id).HasDefaultValueSql("newid()");
            builder.Property(userType => userType.Name).IsRequired().HasMaxLength(150);
        }
    }
}
