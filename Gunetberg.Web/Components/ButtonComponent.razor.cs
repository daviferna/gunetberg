using Gunetberg.Web.BaseComponents;
using Gunetberg.Web.Providers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gunetberg.Web.Components
{
    public partial class ButtonComponent: ThemeableComponent
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public bool Raised { get; set; }

        [Parameter]
        public Action OnClick { get; set; }

    }
}
