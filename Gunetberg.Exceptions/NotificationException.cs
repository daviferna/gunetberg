using System;
using System.Collections.Generic;
using System.Text;

namespace Gunetberg.Exceptions
{
    public class NotificationException: Exception
    {
        public NotificationException(NotificationError error): base(error.ToString())
        {

        }
    }

    public enum NotificationError
    {
        NotCreated
    }
}
