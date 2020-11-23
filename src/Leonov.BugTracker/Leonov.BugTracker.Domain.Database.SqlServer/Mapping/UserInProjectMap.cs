namespace Leonov.BugTracker.Domain.Database.SqlServer.Mapping
{
    using Leonov.BugTracker.Domain.Database.SqlServer.Mapping.Base;
    using Leonov.BugTracker.Domain.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Мапппинг связи пользователя в проекте.
    /// </summary>
    public class UserInProjectMap: BaseEntityMap<UserInProject>
    {
        /// <inheritdoc />
        public override void Configure(EntityTypeBuilder<UserInProject> builder)
        {
            base.Configure(builder);
            builder.ToTable("user_in_project");

            builder.HasOne(up => up.Project)
                .WithMany(p => p.UserInProject)
                .HasForeignKey(up => up.ProjectId);

            builder.HasOne(up => up.User)
                .WithMany(u => u.UserInProject)
                .HasForeignKey(up => up.UserId);
        }
    }
}
