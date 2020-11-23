namespace Leonov.BugTracker.Domain.Database.SqlServer.Mapping
{
    using Leonov.BugTracker.Domain.Database.SqlServer.Mapping.Base;
    using Leonov.BugTracker.Domain.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Маппинг аудитов.
    /// </summary>
    public class AuditMap: BaseEntityMap<Audit>
    {
        /// <inheritdoc />
        public override void Configure(EntityTypeBuilder<Audit> builder)
        {
            base.Configure(builder);
            builder.ToTable("audit");
            builder.Property(x => x.About).HasMaxLength(250);

            builder.HasOne(x => x.ErrorStatus)
                .WithMany()
                .HasForeignKey(x => x.ErrorStatusId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Error)
                .WithMany()
                .HasForeignKey(x => x.ErrorId);
        }
    }
}
