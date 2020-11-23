namespace Leonov.BugTracker.Domain.Database.SqlServer.Mapping
{
    using Leonov.BugTracker.Domain.Database.SqlServer.Mapping.Base;
    using Leonov.BugTracker.Domain.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Маппинг возникновения ошибки.
    /// </summary>
    public class OriginAreaMap: BaseDictionaryMap<OriginArea>
    {
        /// <inheritdoc />
        public override void Configure(EntityTypeBuilder<OriginArea> builder)
        {
            base.Configure(builder);
            builder.ToTable("origin_area");
        }
    }
}
