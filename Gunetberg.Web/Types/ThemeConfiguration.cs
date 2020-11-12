using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gunetberg.Web.Types
{
    public class ThemeConfiguration
    {
        public IDictionary<string, Theme> Themes { get; set; }
        public string DefaultTheme { get; set; }
    }
}
