namespace Leonov.BugTracker.Domain.Services
{
    using System.Collections.Generic;

    using Leonov.BugTracker.Domain.Models.Base;
    using Leonov.BugTracker.Domain.Models.Table;

    /// <inheritdoc />
    public static class TableUtil<T> where T : BaseEntity
    {
        /// <inheritdoc />
        public static TableInfo<T> GetTableInfo(int page, int count, List<string> errors, List<T> value)
        {
            var countOfPages = value.Count % count == 0 && value.Count != 0 ? value.Count / count : value.Count / count + 1;

            if (page > countOfPages)
            {
                errors.Add("Запрашиваемая страница не существует.");
                return null;
            }

            var table = new TableInfo<T>()
            {
                Rows = new List<T>(),
                Count = count,
                CountOfPages = countOfPages,
                Page = page
            };

            for (int i = (page - 1) * count; i < value.Count && i < page * count; i++)
            {
                table.Rows.Add(value[i]);
            }

            return table;
        }
    }
}
