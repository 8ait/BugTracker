namespace Leonov.BugTracker.Domain.Database.SqlServer.Mapping
{
    using Leonov.BugTracker.Domain.Database.SqlServer.Mapping.Base;
    using Leonov.BugTracker.Domain.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Маппинг ошибки.
    /// </summary>
    public class ErrorMap: BaseEntityMap<Error>
    {
        /// <inheritdoc />
        public override void Configure(EntityTypeBuilder<Error> builder)
        {
            base.Configure(builder);
            builder.ToTable("error");
            builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
            builder.Property(x => x.About).HasMaxLength(2000);

            builder.HasOne(x => x.OriginArea)
                .WithMany()
                .HasForeignKey(x => x.OriginId);

            builder.HasOne(x => x.ErrorStatus)
                .WithMany()
                .HasForeignKey(x => x.ErrorStatusId);

            builder.HasOne(x => x.CreateUser)
                .WithMany()
                .HasForeignKey(x => x.CreateUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.ResponsibleUser)
                .WithMany()
                .HasForeignKey(x => x.ResponsibleUserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
