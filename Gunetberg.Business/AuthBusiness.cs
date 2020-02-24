using Gunetberg.Exceptions;
using Gunetberg.Helpers;
using Gunetberg.Infrastructure;
using Gunetberg.Types;
using System.Linq;

namespace Gunetberg.Business
{
    public class AuthBusiness
    {
        private readonly Context _dbContext;

        public AuthBusiness(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public AuthDto AuthenticateUser(AuthRequestDto authRequest)
        {
            /*Validar datos*/
            var user = _dbContext.Users.FirstOrDefault(u =>u.Email == authRequest.Email && u.Password == PasswordHelper.GetHashFromString(authRequest.Password));

            if (user == null)
            {
                throw new AuthenticationInvalidException();
            }
            return new AuthDto { Token = TokenHelper.GenerateToken(user.UserId, user.Role) };
        }
    }
}
