using Gunetberg.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gunetberg.Types.Section
{
    public class SectionDto
    {
        public long SectionId { get; set; }
        public DateTime CreationDate { get; set; }
        public SectionType Type { get; set; }
        public string Content { get; set; }
    }
}
