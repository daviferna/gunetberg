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
        private LateralBarProvider _lateralBarProvider { get; set; }

        [Inject]
        private ThemeProvider _themeProvider { get; set; }


        protected override async Task OnInitializedAsync()
        {
            _lateralBarProvider.OnIsOpenChanged += IsOpenChangedAction;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await _themeProvider.LoadThemeAsync("Light");
            }
        }

        private void IsOpenChangedAction(object sender, bool e)
        {
            StateHasChanged();
        }

    }
}
