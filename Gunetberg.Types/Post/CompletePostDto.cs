using Gunetberg.Types.Section;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gunetberg.Types.Post
{
    public class CompletePostDto:PostDto
    {
        public ICollection<SectionDto> Sections { get; set; }
    }
}
