using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gunetberg.Web.CustomComponents
{
    public partial class PostImageSectionComponent: ComponentBase
    {
        [Parameter]
        public string Source { get; set; }
    }
}
