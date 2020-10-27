using Gunetberg.Business;
using Gunetberg.Types;
using Gunetberg.Types.Tag;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gunetberg.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : BaseApiController
    {
        private readonly TagBusiness _tagBusiness;
        public TagController(TagBusiness tagBusiness)
        {
            _tagBusiness = tagBusiness;
        }


        [Route("list")]
        [HttpGet]
        public ICollection<TagDto> GetTags()
        {
            return _tagBusiness.GetTags();
        }
    }
}
