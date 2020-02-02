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
        EmailIsNullOrWhitespace,
        EmailIsNotValid,
        EmailMaxLengthExceeded,
        AliasIsNullOrWhitespace,
        AliasMaxLengthExceeded,
        PasswordIsNullOrWhitespace,
        PasswordMaxLengthExceeded,
        NotCreated
    }
}
