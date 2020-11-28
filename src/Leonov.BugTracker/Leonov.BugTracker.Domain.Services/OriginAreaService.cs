namespace Leonov.BugTracker.Domain.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Leonov.BugTracker.Domain.Database.SqlServer;
    using Leonov.BugTracker.Domain.Interfaces;
    using Leonov.BugTracker.Domain.Models;

    /// <inheritdoc />
    public class OriginAreaService: IOriginAreaService
    {
        private readonly BugTrackerContext _context;

        /// <summary>
        /// Конструткор.
        /// </summary>
        /// <param name="context"> Контекст данных. </param>
        public OriginAreaService(BugTrackerContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public List<OriginArea> GetAll()
        {
            var originAreas = _context.OriginAreas.ToList();
            return originAreas;
        }
    }
}
