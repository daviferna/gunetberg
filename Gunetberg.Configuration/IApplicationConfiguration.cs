using System;
using System.Collections.Generic;
using System.Text;

namespace Gunetberg.Configuration
{
    public interface IApplicationConfiguration
    {
        string ProfilePictureUrl { get; }
        string ProfilePictureDefaultUrl { get; }
    }
}
