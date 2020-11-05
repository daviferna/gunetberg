using Gunetberg.Web.Providers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gunetberg.Web.Layouts
{
    public partial class MainLayout : LayoutComponentBase
    {
        [Inject]
        private ThemeProvider _themeProvider { get; set; }


        protected override async Task OnInitializedAsync()
        {
            await _themeProvider.UpdateTheme();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

            if (firstRender)
            {
                await _themeProvider.UpdateTheme();
            }
        }
    }
}
