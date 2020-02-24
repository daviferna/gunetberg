using Gunetberg.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Gunetberg.Web.Controllers
{
    public class BaseApiController : ControllerBase
    {
        protected long UserId
        {
            get
            {
                return long.Parse(User.Claims.First(i => i.Type == ClaimTypes.Actor).Value);
            }
        }
    }
}
