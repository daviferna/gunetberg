using Gunetberg.Types.Post;
using Gunetberg.Web.Providers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gunetberg.Web.CustomComponents
{
    public partial class LateralBarComponent : ComponentBase
    {
        [Inject]
        private ThemeProvider _themeProvider { get; set; }

        [Inject]
        private LateralBarProvider _lateralBarProvider { get; set; }

        private bool _isDarkThemeLoaded;

        public bool IsDarkThemeLoaded
        {
            get => _isDarkThemeLoaded;
            set
            {
                _isDarkThemeLoaded = value;
                LoadDarkThemeAsync();
            }
        }


        protected override void OnInitialized()
        {
            _lateralBarProvider.OnIsOpenChanged += IsOpenChangedAction;
        }

        private void IsOpenChangedAction(object sender, bool e)
        {
            StateHasChanged();
        }
    
        private async Task LoadDarkThemeAsync()
        {
            await _themeProvider.LoadThemeAsync(IsDarkThemeLoaded? "Dark": "Light");
        }
    }

}
