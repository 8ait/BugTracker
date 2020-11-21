namespace Leonov.BugTracker.Domain.Database.SqlServer.Mapping
{
    using System;

    using Leonov.BugTracker.Domain.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Маппинг для проекта.
    /// </summary>
    public class ProjectMap: IEntityTypeConfiguration<Project>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("project");
            builder.Property(p => p.Id).HasDefaultValueSql("newid()");
            builder.Property(p => p.Name).IsRequired().HasMaxLength(150);
            builder.Property(p => p.About).HasMaxLength(2000);
        }
    }
}
