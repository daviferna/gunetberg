using System;
using System.Collections.Generic;
using System.Text;

namespace Gunetberg.Domain
{
    public class Post
    {
        public long PostId { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; } 
        public User Author { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
    }
}
