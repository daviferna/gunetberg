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

            builder.Services.AddSingleton<HttpClientProvider>();
            builder.Services.AddSingleton<ThemeProvider>();
            builder.Services.AddSingleton<IHtmlSanitizer, HtmlSanitizer>(sp=>
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
            
            builder.Services.AddTransient<PostService>();
            builder.Services.AddTransient<TagService>();

            await builder.Build().RunAsync();
        }
    }
}
