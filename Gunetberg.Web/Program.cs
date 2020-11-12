using Ganss.XSS;
using Gunetberg.Web.Providers;
using Gunetberg.Web.Services;
using Gunetberg.Web.Types;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace Gunetberg.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddSingleton(sp => new HttpClientProvider("https://gunetberg.azurewebsites.net/"));

            var lightTheme = new Theme
            {
                Primary = "#6200EE",
                PrimaryVariant = "#3700B3",
                Secondary = "#03DAC6",
                SecondaryVariant = "#018786",
                Background = "#EFEFEF",
                Surface = "#FFFFFF",
                Shadow="#DDDDDD",
                Error = "#B00020",
                OnPrimary = "#FFFFFF",
                OnSecondary = "#FFFFFF",
                OnBackground = "#111111",
                OnSurface = "#333333",
                OnError = "#FFFFFF",
            };
           
            var darkTheme = new Theme
            {
                Primary = "#6200EE",
                PrimaryVariant = "#3700B3",
                Secondary = "#03DAC6",
                SecondaryVariant = "#018786",
                Background = "#333333",
                Surface = "#555555",
                Shadow="#222222",
                Error = "#B00020",
                OnPrimary = "#FFFFF",
                OnSecondary = "#FFFFFF",
                OnBackground = "#EEEEEE",
                OnSurface = "#EEEEEE",
                OnError = "#FFFFFF",
            };

            builder.Services.AddSingleton(sp => new ThemeConfiguration
            {
                Themes = new Dictionary<string, Theme>
                {
                    { "Light", lightTheme },
                    { "Dark", darkTheme },
                },
                DefaultTheme = "Dark"
            });
            builder.Services.AddSingleton<ThemeProvider>();
            builder.Services.AddSingleton<LateralBarProvider>();
            builder.Services.AddSingleton<IHtmlSanitizer, HtmlSanitizer>(sp =>
            {
                var sanitizer = new HtmlSanitizer();
                sanitizer.AllowedAttributes.Add("class");
                return sanitizer;
            });

            //Application culture
            var es = new CultureInfo("es");
            var en = new CultureInfo("en");

            builder.Services.AddSingleton(sp => new LocalizationProvider(new LocalizationConfiguration
            {
                DefaultCulture = es,
                SupportedCultures = new CultureInfo[]
                {
                    es,
                    en
                },
                DateTimeFormats = new Dictionary<CultureInfo, string>()
                {
                    { en, "dddd, dd MMMM yyyy"},
                    { es, "dddd, dd MMMM yyyy"}
                },
                ShortDateTimeFormats = new Dictionary<CultureInfo, string>()
                {
                    { en, "dddd, dd MMMM yyyy"},
                    { es, "dddd, dd MMMM yyyy"}
                }
            }));

            //Servicios de la api
            builder.Services.AddTransient<PostService>();
            builder.Services.AddTransient<TagService>();

            await builder.Build().RunAsync();
        }
    }
}
