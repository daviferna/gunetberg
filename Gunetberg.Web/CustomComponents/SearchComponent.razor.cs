using Gunetberg.Web.Providers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gunetberg.Web.CustomComponents
{
    public partial class SearchComponent: ComponentBase
    {

        [Parameter]
        public string Placeholder { get; set; }
    }
}
