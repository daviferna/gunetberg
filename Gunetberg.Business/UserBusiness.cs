using Gunetberg.Domain;
using Gunetberg.Domain.Restrictions;
using Gunetberg.Exceptions;
using Gunetberg.Extension;
using Gunetberg.Helpers;
using Gunetberg.Infrastructure;
using Gunetberg.Types.User;
using System;

namespace Gunetberg.Business
{
    public class UserBusiness
    {
        private readonly Context _dbContext;

        public UserBusiness(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public long CreateUser(UserCreationDto newUser)
        {
            #region validation
            if (newUser.Email.IsNullOrWhitespace()) 
            {
                throw new UserException(UserError.EmailIsNullOrWhitespace);
            }
            if (!newUser.Email.HasEmailFormat())
            {
                throw new UserException(UserError.EmailIsNotValid);
            }
            if(newUser.Email.Length > UserRestrictions.EmailMaxLength)
            {
                throw new UserException(UserError.EmailMaxLengthExceeded);
            }
            if (newUser.Alias.IsNullOrWhitespace())
            {
                throw new UserException(UserError.AliasIsNullOrWhitespace);
            }
            if (newUser.Alias.Length > UserRestrictions.AliasMaxLength)
            {
                throw new UserException(UserError.AliasMaxLengthExceeded);
            }
            if (newUser.Password.IsNullOrWhitespace())
            {
                throw new UserException(UserError.PasswordIsNullOrWhitespace);
            }
            if (newUser.Password.Length > UserRestrictions.PasswordMaxLength)
            {
                throw new UserException(UserError.PasswordMaxLengthExceeded);
            }
            #endregion

            //Create
            var user = new User
            {
                Email = newUser.Email,
                Alias = newUser.Alias,
                CreationDate = DateTime.UtcNow,
                Password = PasswordHelper.GetHashFromString(newUser.Password),
                Role = Role.User
            };

            _dbContext.Users.Add(user);
            
            if(_dbContext.SaveChanges()!= 1)
            {
                throw new UserException(UserError.NotCreated);
            }

            return user.UserId;
        }
    }
}
