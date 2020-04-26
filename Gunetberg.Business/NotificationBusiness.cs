using Gunetberg.Domain;
using Gunetberg.Exceptions;
using Gunetberg.Infrastructure;
using Gunetberg.Types.Notification;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gunetberg.Business
{
    public class NotificationBusiness
    {

        private readonly Context _dbContext;

        public NotificationBusiness(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<NotificationDto> GetNotifications(long userId)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.UserId == userId);

            if (user == null)
            {
                throw new UserException(UserError.DoesNotExist);
            }

            var notifications = _dbContext.Notifications.Where(x => x.User == user && !x.CommitedDate.HasValue).ToList();

            var utcNow = DateTime.UtcNow;

            foreach (var notification in notifications)
            {
                notification.CommitedDate = utcNow;
            }

            _dbContext.SaveChanges();

            return (from n in notifications
                   group n by n.Kind into g
                   select new NotificationDto
                   {
                       Kind = (int)g.Key,
                       Count = g.Count()
                   }).ToList();


        }
    
        public void CreateNotification(NotificationKind kind, long userId)
        {

            var user = _dbContext.Users.FirstOrDefault(x => x.UserId == userId);

            if (user == null)
            {
                throw new UserException(UserError.DoesNotExist);
            }

            Notification notification = new Notification
            {
                Kind = kind,
                User = user
            };

            _dbContext.Notifications.Add(notification);

            if(_dbContext.SaveChanges() != 1)
            {
                throw new NotificationException(NotificationError.NotCreated);
            }

        }
    }
}
