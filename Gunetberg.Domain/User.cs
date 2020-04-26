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
        public Guid? ProfilePicture { get; set; }
        public DateTime CreationDate { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Commentary> Commentaries { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
