using Gunetberg.Business;
using Gunetberg.Types;
using Gunetberg.Types.Notification;
using Gunetberg.Types.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Gunetberg.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : BaseApiController
    { 
        private readonly NotificationBusiness _notificationBusiness;

        public NotificationController(NotificationBusiness notificationBusiness)
        {
            _notificationBusiness = notificationBusiness;
        }

        [Route("get")]
        [HttpGet]
        [Authorize(Roles = "User")]
        public IEnumerable<NotificationDto> GetNotifications()
        {
            return _notificationBusiness.GetNotifications(UserId);
        }
    }
}