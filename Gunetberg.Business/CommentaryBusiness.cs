using Gunetberg.Infrastructure;
using Gunetberg.Types;
using Gunetberg.Types.Commentary;
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

        public PFOCollection<CommentaryDto> GetCommentaries(long postId, int page, int itemsPerPage, long? commentaryId=null, int nestedLevel=0)
        {
            var maxNestedLevel = 2;
            var result = new PFOCollection<CommentaryDto>();

            var posts = _dbContext.Commentaries.Where(x => x.Post.PostId == postId).AsQueryable();

            if(nestedLevel == 0)
            {
                posts.Where(x => x.ResponseTo == null);
            }
            else
            {
                posts.Where(x => x.ResponseTo.CommentaryId == commentaryId);
            }

            #region pagination
            result.ItemsPerPage = itemsPerPage > 10 ? itemsPerPage : 50;
            result.TotalPages = (posts.Count() / result.ItemsPerPage) + 1;
            result.Page = (page > result.TotalPages || page < 1) ? 1 : result.TotalPages;
            var itemsToSkip = (result.Page - 1) * result.ItemsPerPage;
            var itemsToTake = (posts.Count() - itemsToSkip < result.ItemsPerPage) ? posts.Count() - itemsToSkip : result.ItemsPerPage;
            result.Items = (itemsToSkip > 0 ? posts.Skip(itemsToSkip) : posts).Take(itemsToTake).Select(x =>
                 new CommentaryDto
                 {
                     CommentaryId = x.CommentaryId,
                     Content = x.Content,
                     CreationDate = x.CreationDate,
                     Responses = nestedLevel<= maxNestedLevel ? GetCommentaries(postId, 1, 10, x.CommentaryId, nestedLevel+1) : null
                 }).ToList();
            #endregion

            return result;
        }
    
        public CreationResultDto<long> CreateCommentary(CommentaryCreationDto newCommentary)
        {
            return null;
        }
    }
}
