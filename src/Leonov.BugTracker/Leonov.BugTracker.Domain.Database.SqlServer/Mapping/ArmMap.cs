namespace Leonov.BugTracker.Domain.Database.SqlServer.Mapping
{
    using Leonov.BugTracker.Domain.Database.SqlServer.Mapping.Base;
    using Leonov.BugTracker.Domain.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Маппинг права.
    /// </summary>
    public class ArmMap: BaseDictionaryMap<Arm>
    {
        /// <inheritdoc />
        public override void Configure(EntityTypeBuilder<Arm> builder)
        {
            base.Configure(builder);
            builder.ToTable("arm");
        }
    }
}
