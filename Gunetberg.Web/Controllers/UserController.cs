using Gunetberg.Business;
using Gunetberg.Types.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gunetberg.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseApiController
    {
        private readonly UserBusiness _userBusiness;

        public UserController(UserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [Route("create")]
        [HttpPost]
        public UserCreationResultDto CreateUser(UserCreationDto newUser)
        {
            return _userBusiness.CreateUser(newUser);
        }

        [Route("get")]
        [HttpGet]
        [Authorize(Roles = "User")]
        public UserDetail GetUser()
        {
            return _userBusiness.GetUser(UserId);
        }
    }
}