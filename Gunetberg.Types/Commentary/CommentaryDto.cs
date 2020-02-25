using System;
using System.Collections.Generic;
using System.Text;

namespace Gunetberg.Types.Commentary
{
    public class CommentaryDto
    {
        public long CommentaryId { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public bool HasAnyResponse { get; set; }
    }
}
