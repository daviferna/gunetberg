using Gunetberg.Web.BaseComponents;
using Microsoft.AspNetCore.Components;

namespace Gunetberg.Web.Components
{
    public partial class LabelComponent: ThemeableComponent
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

    }
}
