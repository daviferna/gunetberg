using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gunetberg.Web.CustomComponents
{
    public partial class PostCodeSectionComponent: ComponentBase
    {
        [Parameter]
        public string Code { get; set; }
    }
}
