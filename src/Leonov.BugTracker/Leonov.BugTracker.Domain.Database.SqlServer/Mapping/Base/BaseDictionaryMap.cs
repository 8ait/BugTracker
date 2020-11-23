namespace Leonov.BugTracker.Domain.Database.SqlServer.Mapping.Base
{
    using Leonov.BugTracker.Domain.Models.Base;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Маппинг словарной сущности.
    /// </summary>
    public abstract class BaseDictionaryMap<T>: IEntityTypeConfiguration<T> where T : BaseDictionaryEntity
    {
        /// <inheritdoc />
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        }
    }
}
