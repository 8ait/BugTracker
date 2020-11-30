namespace Leonov.BugTracker.Domain.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Leonov.BugTracker.Domain.Database.SqlServer;
    using Leonov.BugTracker.Domain.Interfaces;
    using Leonov.BugTracker.Domain.Models;

    using Microsoft.EntityFrameworkCore;

    /// <inheritdoc />
    public class CommentaryService: ICommentaryService
    {
        private readonly BugTrackerContext _context;

        public CommentaryService(BugTrackerContext context)
        {
            _context = context;
        }

        public Task<Commentary> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(Commentary entity, List<string> errors)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task CreateAsync(Commentary entity, List<string> errors)
        {
            _context.Add(entity);
            await _context.TrySaveChangesAsync(errors);
        }

        public Task DeleteAsync(Guid id, List<string> errors)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task<List<Commentary>> GetCommentariesByError(Guid errorId, List<string> errors)
        {
            var error = await _context.Errors.FindAsync(errorId);

            if (error is null)
            {
                errors.Add("Неверный идентификатор ошибки.");
                return Enumerable.Empty<Commentary>().ToList();
            }

            var commentaries = await _context.Commentaries
                .Include(x => x.User)
                .Where(x => !x.ParentId.HasValue && x.ErrorId == errorId)
                .ToListAsync();

            foreach (var commentary in commentaries)
            {
                IncludeChilds(commentary);
            }

            return commentaries;
        }

        private void IncludeChilds(Commentary commentary)
        {
            var childs = _context.Commentaries
                .Where(x => x.ParentId == commentary.Id)
                .Include(x => x.Parent).ThenInclude(x => x.User)
                .Include(x => x.User);
            commentary.Commentaries = childs.ToList();
            foreach (var com in commentary.Commentaries)
            {
                IncludeChilds(com);
            }
        }
    }
}
