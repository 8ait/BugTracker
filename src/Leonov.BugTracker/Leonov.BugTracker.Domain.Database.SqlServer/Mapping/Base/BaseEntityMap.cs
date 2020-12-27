namespace Leonov.BugTracker.Domain.Database.SqlServer.Mapping.Base
{
    using Leonov.BugTracker.Domain.Models.Base;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Маппинг для базовой сущности БД.
    /// </summary>
    /// <typeparam name="T"> Тип сущности. </typeparam>
    public abstract class BaseEntityMap<T>: IEntityTypeConfiguration<T> where T : BaseEntity
    {
        /// <inheritdoc />
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(p => p.Id).HasDefaultValueSql("uuid_generate_v4()");
        }
    }
}
