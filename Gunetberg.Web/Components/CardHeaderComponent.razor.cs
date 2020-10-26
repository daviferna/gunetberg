using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gunetberg.Web.Components
{
    public partial class CardHeaderComponent: ComponentBase
    {
        [Parameter]
        public string Header { get; set; }
    }
}
