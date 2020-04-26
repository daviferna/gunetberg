using System;
using System.Collections.Generic;
using System.Text;

namespace Gunetberg.Domain
{
    public class Commentary
    {
        public long CommentaryId { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual User Author { get; set; }
        public virtual Post Post { get; set; }
        public virtual Commentary ResponseTo { get; set; }
        public virtual ICollection<Commentary> Commentaries { get; set; }
    }
}
