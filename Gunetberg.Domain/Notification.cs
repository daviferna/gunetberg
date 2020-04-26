using System;
using System.Collections.Generic;
using System.Text;

namespace Gunetberg.Domain
{
    public class Notification
    {
        public long NotificationId { get; set; }
        public DateTime? CommitedDate { get; set; }
        public NotificationKind Kind { get; set; }

        public virtual User User { get; set; }
    }
}
