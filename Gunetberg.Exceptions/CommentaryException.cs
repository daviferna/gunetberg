using System;
using System.Collections.Generic;
using System.Text;

namespace Gunetberg.Exceptions
{
    public class CommentaryException:Exception
    {
        public CommentaryException(CommentaryError error) : base(error.ToString())
        {

        }
    }

    public enum CommentaryError
    {
        RequestIsEmpty,
        ContentIsNullOrWhitespace,
        DoesNotExist,
        ContentMaxLengthExceeded
    }
}
