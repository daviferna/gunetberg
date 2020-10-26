using Gunetberg.Web.Providers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gunetberg.Web.BaseComponents
{
    public abstract class ThemeableComponent: ComponentBase
    {
        [Inject]
        public ThemeProvider ThemeProvider { get; private set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ThemeProvider.OnThemeChanged += OnThemeChangedAction;
        }

        private void OnThemeChangedAction(object sender, EventArgs e)
        {
           StateHasChanged();
        }
    }
}
