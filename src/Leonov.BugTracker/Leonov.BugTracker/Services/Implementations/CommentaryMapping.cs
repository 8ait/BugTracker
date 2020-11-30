namespace Leonov.BugTracker.Services.Implementations
{
    using System;
    using System.Collections.Generic;

    using Leonov.BugTracker.Domain.Models;
    using Leonov.BugTracker.Dto;
    using Leonov.BugTracker.Services.Interfaces;

    /// <inheritdoc />
    public class CommentaryMapping: ICommentaryMapping
    {
        /// <inheritdoc />
        public Commentary AddCommentaryDtoToCommentary(AddCommentaryDto addCommentaryDto)
        {
            return new Commentary()
            {
                ErrorId = addCommentaryDto.ErrorId,
                Value = addCommentaryDto.Value,
                ParentId = addCommentaryDto.ParentId,
                CreateDate = DateTime.Now
            };
        }

        /// <inheritdoc />
        public List<CommentaryInfoDto> CommentariesToComeCommentaryInfoDtos(List<Commentary> commentaries)
        {
            var commentarieDtos = new List<CommentaryInfoDto>();
            foreach (var com in commentaries)
            {
                commentarieDtos.Add(CommentaryToCommentaryInfoDto(com));
            }

            return commentarieDtos;
        }

        private CommentaryInfoDto CommentaryToCommentaryInfoDto(Commentary commentary)
        {
            var childrens = new List<CommentaryInfoDto>();

            foreach (var com in commentary.Commentaries)
            {
                childrens.Add(CommentaryToCommentaryInfoDto(com));   
            }

            return new CommentaryInfoDto()
            {
                Id = commentary.Id,
                Value = commentary.Value,
                UserName = $"{commentary.User.FirstName} {commentary.User.Surname}",
                CreateDateTime = $"{commentary.CreateDate.ToShortTimeString()} {commentary.CreateDate.ToShortDateString()}",
                ParentUsername = commentary.Parent is null ? null : $"{commentary.Parent.User.FirstName} {commentary.Parent.User.Surname}",
                Childrens = childrens
            };
        }
    }
}
