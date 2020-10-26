using System;
using System.Collections.Generic;
using System.Text;

namespace Gunetberg.Domain
{
    public class Post
    {
        public long PostId { get; set; }
        public string Title { get; set; }
        public string HeaderImage { get; set; }
        public DateTime CreationDate { get; set; } 
        public virtual User Author { get; set; }
        public DateTime? FeaturedDate { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
        public virtual ICollection<Commentary> Commentaries { get; set; }
        public virtual ICollection<PostTag> PostTags { get; set; }
    }
}
