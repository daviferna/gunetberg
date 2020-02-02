using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gunetberg.Business;
using Gunetberg.Types;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gunetberg.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostBusiness _postBusiness;

        public PostController(PostBusiness postBusiness)
        {
            _postBusiness = postBusiness;
        }

        [Route("getposts")]
        [Authorize(Roles = "User")]
        [HttpGet]
        public PFOCollection<PostDto> GetPosts(string title, DateTime? from, DateTime? to, string orderBy, bool orderByDescending, int page, int itemsPerPage)
        {
            return _postBusiness.GetPosts(title, from, to, orderBy, orderByDescending, page, itemsPerPage);
        }
    }
}