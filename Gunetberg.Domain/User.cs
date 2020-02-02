using System;
using System.Collections.Generic;
using System.Text;

namespace Gunetberg.Domain
{
    public class User
    {
        public long UserId { get; set; }
        public string Email { get; set; }
        public string Alias { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid Password { get; set; }
        public Role Role { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public bool IsDeleted { get; set; }
    }
}
