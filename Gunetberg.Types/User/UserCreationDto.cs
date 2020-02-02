using System;
using System.Collections.Generic;
using System.Text;

namespace Gunetberg.Types.User
{
    public class UserCreationDto
    {
        public string Email { get; set; }
        public string Alias { get; set; }
        public string Password { get; set; }
    }
}
