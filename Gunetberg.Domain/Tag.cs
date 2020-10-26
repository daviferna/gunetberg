using System;
using System.Collections.Generic;
using System.Text;

namespace Gunetberg.Domain
{
    public class Tag
    {
        public long TagId { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual ICollection<PostTag> PostTags { get; set; }
    }
}
