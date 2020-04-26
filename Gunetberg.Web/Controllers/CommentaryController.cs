using Gunetberg.Business;
using Gunetberg.Types;
using Gunetberg.Types.Commentary;
using Gunetberg.Types.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gunetberg.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentaryController : BaseApiController
    {
        private readonly CommentaryBusiness _commentaryBusiness;

        public CommentaryController(CommentaryBusiness commentaryBusiness)
        {
            _commentaryBusiness = commentaryBusiness;
        }

        [Route("create")]
        [HttpPost]
        [Authorize(Roles = "User")]
        public CreationResultDto<long> CreateCommentary(CommentaryCreationDto newCommentary)
        {
            return _commentaryBusiness.CreateCommentary(newCommentary, UserId);
        }

        [Route("list")]
        [HttpGet]
        public PFOCollection<CommentaryDto> GetCommentaries(long postId, int page, int itemsPerPage, long? commentaryId)
        {
            return _commentaryBusiness.GetCommentaries(postId, page, itemsPerPage, commentaryId);
        }
    }
}