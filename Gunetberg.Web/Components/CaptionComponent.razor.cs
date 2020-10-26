using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gunetberg.Web.Components
{
    public partial class CaptionComponent:ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
