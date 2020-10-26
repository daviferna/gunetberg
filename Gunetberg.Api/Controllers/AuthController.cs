using Gunetberg.Business;
using Gunetberg.Types;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gunetberg.Api.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthBusiness _authBusiness;
        public AuthController(AuthBusiness authBusiness)
        {
            _authBusiness = authBusiness;
        }


        [Route("api/auth")]
        [HttpPost]
        public AuthDto Auth([FromBody] AuthRequestDto authRequest)
        {
            return _authBusiness.AuthenticateUser(authRequest);
        }
    }
}
