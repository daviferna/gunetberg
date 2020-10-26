using Gunetberg.Types.Section;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gunetberg.Types.Post
{
    public class CompletePostDto:PostDto
    {
        public System.Collections.Generic.ICollection<SectionDto> Sections { get; set; }
    }
}
