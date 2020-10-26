using Gunetberg.Web.Types;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Gunetberg.Web.Providers
{
    public class LocalizationProvider
    {
        public CultureInfo[] SupportedCultures { get; set; }
        public CultureInfo CurrentCulture { get; private set; }

        public IDictionary<CultureInfo, string> DateTimeFormats { get; set; }

        public IDictionary<CultureInfo, string> ShortDateTimeFormats { get; set; }

        public LocalizationProvider(LocalizationConfiguration configuration)
        {
            SupportedCultures = configuration.SupportedCultures;
            CurrentCulture = configuration.DefaultCulture;
            DateTimeFormats = configuration.DateTimeFormats;
            ShortDateTimeFormats = configuration.ShortDateTimeFormats;
            UseCulture(CurrentCulture);
        }

        public void UseCulture(CultureInfo culture)
        {
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }

        public string Get(string key)
        {
            try
            {
                return Localization.Localization.ResourceManager.GetString(key, CurrentCulture);
            }
            catch
            {
                return string.Empty;
            }
        }

        public string FormatDate(DateTime dateTime)
        {
            return dateTime.ToString(DateTimeFormats[CurrentCulture]);
        }
    
        public string ShortDate(DateTime dateTime)
        {
            return dateTime.ToString(ShortDateTimeFormats[CurrentCulture]);
        }

    }
}
