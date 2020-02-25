using System;
using System.Collections.Generic;
using System.Text;

namespace Gunetberg.Types.Commentary
{
    public class CommentaryCreationDto
    {
        public string Content { get; set; }
        public long ResponseTo { get; set; }
    }
}
