﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Gunetberg.Types.User
{
    public class UserDetail
    {
        public long UserId { get; set; }
        public string Email { get; set; }
        public string Alias { get; set; }
        public string ProfilePicture { get; set; }
    }
}
