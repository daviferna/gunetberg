using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gunetberg.Web.Types
{
    public class Theme
    {
        public string Primary { get; set; }
        public string PrimaryVariant { get; set; }
        public string Secondary { get; set; }
        public string SecondaryVariant { get; set; }
        public string Background { get; set; }
        public string Surface { get; set; }
        public string Shadow { get; set; }
        public string Error { get; set; }
        public string OnPrimary { get; set; }
        public string OnSecondary { get; set; }
        public string OnBackground { get; set; }
        public string OnSurface { get; set; }
        public string OnError { get; set; }
    }
}
