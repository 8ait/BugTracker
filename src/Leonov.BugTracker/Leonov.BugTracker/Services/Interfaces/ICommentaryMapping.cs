namespace Leonov.BugTracker.Services.Interfaces
{
    using System.Collections.Generic;

    using Leonov.BugTracker.Domain.Models;
    using Leonov.BugTracker.Dto;

    /// <summary>
    /// Маппинг для коммментариев.
    /// </summary>
    public interface ICommentaryMapping
    {
        /// <summary>
        /// Дто добавления комменатрия в комментарий.
        /// </summary>
        /// <param name="addCommentaryDto"></param>
        /// <returns></returns>
        public Commentary AddCommentaryDtoToCommentary(AddCommentaryDto addCommentaryDto);

        /// <summary>
        /// Список комментариев в дто для комментариев.
        /// </summary>
        /// <param name="commentaries"></param>
        /// <returns></returns>
        public List<CommentaryInfoDto> CommentariesToComeCommentaryInfoDtos(List<Commentary> commentaries);
    }
}
