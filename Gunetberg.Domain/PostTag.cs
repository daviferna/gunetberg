using System;
using System.Collections.Generic;
using System.Text;

namespace Gunetberg.Domain
{
    public class PostTag
    {
        public long PostId { get; set; }
        public long TagId { get; set; }

        public virtual Post Post { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
