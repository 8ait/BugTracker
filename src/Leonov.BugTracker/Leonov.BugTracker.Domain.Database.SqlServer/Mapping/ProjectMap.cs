namespace Leonov.BugTracker.Domain.Database.SqlServer.Mapping
{
    using Leonov.BugTracker.Domain.Database.SqlServer.Mapping.Base;
    using Leonov.BugTracker.Domain.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Маппинг для проекта.
    /// </summary>
    public class ProjectMap: BaseEntityMap<Project>
    {
        /// <inheritdoc />
        public override void Configure(EntityTypeBuilder<Project> builder)
        {
            base.Configure(builder);
            builder.ToTable("project");
            builder.Property(p => p.Name).IsRequired().HasMaxLength(150);
            builder.Property(p => p.About).HasMaxLength(2000);
        }
    }
}
