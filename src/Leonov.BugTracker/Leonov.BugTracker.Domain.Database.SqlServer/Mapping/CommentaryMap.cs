namespace Leonov.BugTracker.Domain.Database.SqlServer.Mapping
{
    using Leonov.BugTracker.Domain.Database.SqlServer.Mapping.Base;
    using Leonov.BugTracker.Domain.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Маппинг комментария.
    /// </summary>
    public class CommentaryMap: BaseEntityMap<Commentary>
    {
        /// <inheritdoc />
        public override void Configure(EntityTypeBuilder<Commentary> builder)
        {
            base.Configure(builder);
            builder.ToTable("commentary");
            builder.Property(x => x.Value).IsRequired().HasMaxLength(2000);

            builder.HasOne(x => x.Parent)
                .WithMany()
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Error)
                .WithMany()
                .HasForeignKey(x => x.ErrorId);

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);
        }
    }
}
