using Gunetberg.Types.Post;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gunetberg.Web.CustomComponents
{
    public partial class LateralBarComponent: ComponentBase
    {
        public PostDto LastPosts { get; set; }
    }
}
