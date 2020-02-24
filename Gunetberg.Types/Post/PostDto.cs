using System;
using System.Collections.Generic;
using System.Text;

namespace Gunetberg.Types.Post
{
    public class PostDto
    {
        public long PostId { get; set; }
        public string Title { get; set; }
        public string HeaderImage { get; set; }
        public DateTime CreationDate { get; set; }
        public string AuthorAlias { get; set; }
    }
}
