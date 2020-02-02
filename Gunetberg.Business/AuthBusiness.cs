using Gunetberg.Helpers;
using Gunetberg.Infrastructure;
using Gunetberg.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            var user = _dbContext.Users.FirstOrDefault(u =>u.Email == authRequest.Email && u.Password == PasswordHelper.GetHash(authRequest.Password));

            if (user == null)
            {
                throw new Exception();
            }
            return new AuthDto { Token = TokenHelper.GenerateToken(user.UserId, user.Role) };
        }
    }
}
