using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gunetberg.Web.CustomComponents
{
    public partial class PostItemComponent: ComponentBase
    {
        
        [Parameter]
        public long PostId { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string Description { get; set; }

        [Parameter]
        public string HeaderImage { get; set; }

        [Parameter]
        public DateTime CreationDate { get; set; }

        [Parameter]
        public string[] Tags { get; set; }

        [Parameter]
        public Action OnClick { get; set; }

    }
}
