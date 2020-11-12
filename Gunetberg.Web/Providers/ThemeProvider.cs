using Gunetberg.Web.Types;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gunetberg.Web.Providers
{
    public class ThemeProvider
    {
        private IJSRuntime _jSRuntime { get; set; }

        public EventHandler OnThemeChanged;

        private IDictionary<string, Theme> _themes;

        private string _currentTheme;

        private string _defaultTheme;

        public ThemeProvider(IJSRuntime jSRuntime, ThemeConfiguration themeConfiguration)
        {
            _jSRuntime = jSRuntime;
            _themes = themeConfiguration.Themes;
            _defaultTheme = themeConfiguration.DefaultTheme;
        }

        public string GetCurrentThemeName()
        {
            return _currentTheme;
        }

        public async Task LoadThemeAsync(string themeName)
        {
            var availableThemes = _themes.Keys;

            if (availableThemes.Contains(themeName))
                _currentTheme = themeName;
            else if (availableThemes.Contains(_defaultTheme))
                _currentTheme = _defaultTheme;
            else
                _currentTheme = availableThemes.First();


            await UpdateThemeAsync();
        }

        private async Task UpdateThemeAsync()
        {
            await _jSRuntime.InvokeVoidAsync("loadTheme", _themes[_currentTheme]);
            OnThemeChanged?.Invoke(this, null);
        }
    }
}
