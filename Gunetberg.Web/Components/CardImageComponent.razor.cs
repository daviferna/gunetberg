using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gunetberg.Web.Components
{
    public partial class CardImageComponent:ComponentBase
    {
        [Parameter]
        public string Source { get; set; }
    }
}
