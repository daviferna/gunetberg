using Gunetberg.Web.Providers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gunetberg.Web.Components
{
    public partial class ProgressComponent: ComponentBase
    {
        [Inject]
        private ThemeProvider _themeProvider { get; set; }
    }
}
