namespace Leonov.BugTracker.Domain.Database.SqlServer.Mapping
{
    using Leonov.BugTracker.Domain.Database.SqlServer.Mapping.Base;
    using Leonov.BugTracker.Domain.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Маппинг статуса ошибки.
    /// </summary>
    public class ErrorStatusMap: BaseDictionaryMap<ErrorStatus>
    {
        /// <inheritdoc />
        public override void Configure(EntityTypeBuilder<ErrorStatus> builder)
        {
            base.Configure(builder);
            builder.ToTable("error_status");
        }
    }
}
