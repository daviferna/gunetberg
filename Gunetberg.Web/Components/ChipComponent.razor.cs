using Gunetberg.Web.BaseComponents;
using Gunetberg.Web.Providers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gunetberg.Web.Components
{
    public partial class ChipComponent : ThemeableComponent
    {

        [Parameter]
        public bool IsSecondary { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

    }
}
