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
        private readonly IJSRuntime _jSRuntime;

        public EventHandler OnThemeChanged;

        private string _primary;
        public string Primary
        {
            get => _primary;
            set
            {
                _primary = value;
                UpdateTheme().Wait();;
            }
        }

        private string _primaryVariant;
        public string PrimaryVariant { 
            get=>_primaryVariant;
            set
            {
                _primaryVariant = value;
                UpdateTheme().Wait();;
            }
        }

        private string _secondary;
        public string Secondary
        {
            get => _secondary;
            set
            {
                _secondary = value;
                UpdateTheme().Wait();;
            }
        }

        private string _secondaryVariant;
        public string SecondaryVariant
        {
            get => _secondaryVariant;
            set
            {
                _secondaryVariant = value;
                UpdateTheme().Wait();;
            }
        }

        private string _background;
        public string Background
        {
            get => _background;
            set
            {
                _background = value;
                UpdateTheme().Wait();;
            }
        }

        private string _surface;
        public string Surface { 
            get=>_surface;
            set
            {
                _surface = value;
                UpdateTheme().Wait();;
            }
        }

        private string _error;
        public string Error { 
            get=>_error;
            set
            {
                _error = value;
                UpdateTheme().Wait();;
            }
        }

        private string _onPrimary;
        public string OnPrimary
        {
            get => _onPrimary;
            set
            {
                _onPrimary = value;
                UpdateTheme().Wait();;
            }
        }

        private string _onSecondary;
        public string OnSecondary
        {
            get => _onSecondary;
            set
            {
                _onSecondary = value;
                UpdateTheme().Wait();;
            }
        }

        private string _onBackground;
        public string OnBackground
        {
            get => _onBackground;
            set
            {
                _onBackground = value;
                UpdateTheme().Wait();;
            }
        }

        private string _onSurface;
        public string OnSurface
        {
            get => _onSurface;
            set
            {
                _onSurface = value;
                UpdateTheme().Wait();;
            }
        }

        private string _onError;
        public string OnError
        {
            get => _onError;
            set
            {
                _onError = value;
                UpdateTheme().Wait();
            }
        }

        public ThemeProvider(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
            _primary = "#6200EE";
            _primaryVariant = "#3700B3";
            _secondary = "#03DAC6";
            _secondaryVariant = "#018786";
            _background = "#FFFFFF";
            _surface = "#FFFFFF";
            _error = "#B00020";
            _onPrimary = "#FFFFFF";
            _onSecondary = "#FFFFFF";
            _onBackground = "#000000";
            _onSurface = "#DDDDDD";
            _onError = "#FFFFFF";
        }
    
        public async Task UpdateTheme()
        {
            await _jSRuntime.InvokeVoidAsync("loadTheme", this);
            OnThemeChanged?.Invoke(this, null);
        }
    }
}
