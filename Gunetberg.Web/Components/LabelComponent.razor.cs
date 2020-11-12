using Microsoft.AspNetCore.Components;

namespace Gunetberg.Web.Components
{
    public partial class LabelComponent: ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

    }
}
