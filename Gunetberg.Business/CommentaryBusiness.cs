using Gunetberg.Domain;
using Gunetberg.Domain.Restrictions;
using Gunetberg.Exceptions;
using Gunetberg.Infrastructure;
using Gunetberg.Types;
using Gunetberg.Types.Commentary;
using System;
using System.Linq;

namespace Gunetberg.Business
{
    public class CommentaryBusiness
    {
        private readonly Context _dbContext;

        public CommentaryBusiness(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public PFOCollection<CommentaryDto> GetCommentaries(long postId, int page, int itemsPerPage, long? commentaryId = null)
        {
            var result = new PFOCollection<CommentaryDto>();

            var commentaries = _dbContext.Commentaries.Where(x => x.Post.PostId == postId).AsQueryable();

            if (!commentaries.Any())
            {
                throw new CommentaryException(CommentaryError.DoesNotExist);
            }

            if (!commentaryId.HasValue)
            {
                commentaries = commentaries.Where(x => x.ResponseTo == null);
            }
            else
            {
                commentaries= commentaries.Where(x => x.ResponseTo.CommentaryId == commentaryId);
            }

            #region pagination
            result.ItemsPerPage = itemsPerPage > 10 ? itemsPerPage : 50;
            result.TotalPages = (commentaries.Count() / result.ItemsPerPage) + 1;
            result.Page = (page > result.TotalPages || page < 1) ? 1 : result.TotalPages;
            var itemsToSkip = (result.Page - 1) * result.ItemsPerPage;
            var itemsToTake = (commentaries.Count() - itemsToSkip < result.ItemsPerPage) ? commentaries.Count() - itemsToSkip : result.ItemsPerPage;
            result.Items = (itemsToSkip > 0 ? commentaries.Skip(itemsToSkip) : commentaries).Take(itemsToTake).Select(x =>
                 new CommentaryDto
                 {
                     CommentaryId = x.CommentaryId,
                     Content = x.Content,
                     CreationDate = x.CreationDate,
                     HasAnyResponse = _dbContext.Commentaries.Any(y => y.Post.PostId == postId && y.ResponseTo.CommentaryId == x.CommentaryId)
                 }).ToList();
            #endregion

            return result;
        }

        public CreationResultDto<long> CreateCommentary(CommentaryCreationDto newCommentary, long userId)
        {
            if (newCommentary == null)
            {
                throw new CommentaryException(CommentaryError.RequestIsEmpty);
            }
            if (string.IsNullOrWhiteSpace(newCommentary.Content))
            {
                throw new CommentaryException(CommentaryError.ContentIsNullOrWhitespace);
            }
            if(newCommentary.Content.Length > CommentaryRestrictions.ContentMaxLength)
            {
                throw new CommentaryException(CommentaryError.ContentMaxLengthExceeded);
            }

            var user = _dbContext.Users.FirstOrDefault(x => x.UserId == userId);

            if (user == null)
            {
                throw new UserException(UserError.DoesNotExist);
            }

            var post = _dbContext.Posts.FirstOrDefault(x => x.PostId == newCommentary.PostId);

            if (post == null)
            {
                throw new PostException(PostError.PostDoesNotExist);
            }

            //Create
            var commentary = new Commentary
            {
                Author = user,
                Content = newCommentary.Content,
                Post = post,
                CreationDate = DateTime.UtcNow
            };

            if (newCommentary.ResponseTo.HasValue) {
                var responseTo = _dbContext.Commentaries.FirstOrDefault(x => x.CommentaryId == newCommentary.ResponseTo.Value);
                if(responseTo == null)
                {
                    throw new CommentaryException(CommentaryError.DoesNotExist);
                }
                commentary.ResponseTo = responseTo;
            }

            _dbContext.Commentaries.Add(commentary);
            _dbContext.SaveChanges();

            return new CreationResultDto<long>
            {
                Id = commentary.CommentaryId
            };
        }
    }
}
