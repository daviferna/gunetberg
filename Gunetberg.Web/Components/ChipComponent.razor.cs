using Gunetberg.Web.Providers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gunetberg.Web.Components
{
    public partial class ChipComponent : ComponentBase
    {
        [Parameter]
        public bool IsSecondary { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public bool IsSelectable { get; set; }
    
        private Guid Id { get; set; }


        protected override void OnInitialized()
        {
            Id = Guid.NewGuid();
        }


    }
}
