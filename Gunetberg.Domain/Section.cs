using System;
using System.Collections.Generic;
using System.Text;

namespace Gunetberg.Domain
{
    public class Section
    {
        public long SectionId { get; set; }
        public DateTime CreationDate { get; set; }
        public SectionType Type { get; set; }
        public string Content { get; set; }
        public virtual Post Post { get; set; }
    }
}
