using Gunetberg.Web.Providers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gunetberg.Web.Layouts
{
    public partial class MainLayout: LayoutComponentBase
    {

        [Inject]
        private ThemeProvider _themeProvider { get; set; }

        public void ChangeTheme()
        {
            _themeProvider.Primary = "#000";
        }
    }
}
