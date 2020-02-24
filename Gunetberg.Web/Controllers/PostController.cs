using System;
using System.Threading.Tasks;
using Gunetberg.Business;
using Gunetberg.Types;
using Gunetberg.Types.Post;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gunetberg.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : BaseApiController
    {
        private readonly PostBusiness _postBusiness;

        public PostController(PostBusiness postBusiness)
        {
            _postBusiness = postBusiness;
        }

        [Route("list")]
        [HttpGet]
        public PFOCollection<PostDto> GetPosts(string title, DateTime? from, DateTime? to, string orderBy, bool orderByDescending, int page, int itemsPerPage)
        {
            return _postBusiness.GetPosts(title, from, to, orderBy, orderByDescending, page, itemsPerPage);
        }

        [Route("get")]
        [HttpGet]
        public CompletePostDto GetPost(long postId)
        {
            return _postBusiness.GetPost(postId);
        }

        [Route("create")]
        [Authorize(Roles = "User")]
        [HttpPost]
        public PostCreationResultDto CreatePost(PostCreationDto newPost)
        {
            return _postBusiness.CreatePost(newPost, UserId);
        }
    }
}