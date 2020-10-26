using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Gunetberg.Web.Types
{
    public class LocalizationConfiguration
    {
        public CultureInfo[] SupportedCultures { get; set; }

        public CultureInfo DefaultCulture{ get; set; }

        public IDictionary<CultureInfo, string> DateTimeFormats { get; set; }
        public IDictionary<CultureInfo, string> ShortDateTimeFormats { get; set; }

    }
}
