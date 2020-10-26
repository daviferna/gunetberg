using Gunetberg.Business;
using Gunetberg.Types;
using Gunetberg.Types.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Gunetberg.Api.Controllers
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
        public CreationResultDto<long> CreateUser(UserCreationDto newUser)
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
    
        
        [Route("updateprofilepicture")]
        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<CreationResultDto<string>> UpdateProfilePicture(UserUpdateProfilePicture userUpdateProfilePicture)
        {
           return await _userBusiness.UpdateProfilePicture(UserId, userUpdateProfilePicture);
        }

        [Route("summary")]
        [HttpGet]
        [Authorize(Roles = "User")]
        public UserSummary GetUserSummary()
        {
            return _userBusiness.GetUserSummary(UserId);
        }
    }
}