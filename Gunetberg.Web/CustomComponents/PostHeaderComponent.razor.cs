using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gunetberg.Web.CustomComponents
{
    public partial class PostHeaderComponent: ComponentBase
    {
        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string HeaderImage { get; set; }

        [Parameter]
        public DateTime CreationDate { get; set; }
    }
}
