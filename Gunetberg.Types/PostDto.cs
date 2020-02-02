using System;
using System.Collections.Generic;
using System.Text;

namespace Gunetberg.Types
{
    public class PostDto
    {
        public long PostId { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public string AuthorAlias { get; set; }
    }
}
