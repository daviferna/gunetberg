using Gunetberg.Business;
using Gunetberg.Types.User;
using Microsoft.AspNetCore.Mvc;

namespace Gunetberg.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserBusiness _userBusiness;

        public UserController(UserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [Route("create")]
        [HttpPost]
        public long CreateUser(UserCreationDto newUser)
        {
            return _userBusiness.CreateUser(newUser);
        }
    }
}