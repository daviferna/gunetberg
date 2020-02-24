using System;
using System.Collections.Generic;
using System.Text;

namespace Gunetberg.Exceptions
{
    public class UserException: Exception
    {
        public UserException(UserError error): base(error.ToString())
        {

        }
    }

    public enum UserError
    {
        RequestIsEmpty,
        EmailIsNullOrWhitespace,
        EmailIsNotValid,
        EmailMaxLengthExceeded,
        EmailAlreadyExists,
        AliasIsNullOrWhitespace,
        AliasMaxLengthExceeded,
        AliasAlreadyExists,
        PasswordIsNullOrWhitespace,
        PasswordMaxLengthExceeded,
        NotCreated,
        DoesNotExist
    }
}
