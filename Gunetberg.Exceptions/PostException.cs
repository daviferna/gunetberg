using System;


namespace Gunetberg.Exceptions
{
    public class PostException: Exception
    {
        public PostException(PostError error): base(error.ToString())
        {

        }
    }

    public enum PostError
    {
        RequestIsEmpty,
        PostDoesNotExist,
        TitleIsNullOrWhitespace,
        TitleMaxLengthExceeded
    }
}
