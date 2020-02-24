using Gunetberg.Types.Section;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gunetberg.Types.Post
{
    public class PostCreationDto
    {
        public string Title { get; set; }
        public string HeaderImage { get; set; }
        public ICollection<SectionCreationDto> Sections { get; set; }
    }
}
