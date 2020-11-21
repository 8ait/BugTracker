namespace Leonov.BugTracker.Domain.Database.SqlServer.Mapping
{
    using Leonov.BugTracker.Domain.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Мапппинг связи пользователя в проекте.
    /// </summary>
    public class UserInProjectMap: IEntityTypeConfiguration<UserInProject>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<UserInProject> builder)
        {
            builder.ToTable("user_in_project");
            builder.Property(p => p.Id).HasDefaultValueSql("newid()");

            builder.HasOne(up => up.Project)
                .WithMany(p => p.UserInProject)
                .HasForeignKey(up => up.ProjectId);

            builder.HasOne(up => up.User)
                .WithMany(u => u.UserInProject)
                .HasForeignKey(up => up.UserId);
        }
    }
}
