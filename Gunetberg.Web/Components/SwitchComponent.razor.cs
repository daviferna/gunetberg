using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gunetberg.Web.Components
{
    public partial class SwitchComponent : ComponentBase
    {
        [Parameter]
        public bool Value { get; set; }


        [Parameter]
        public EventCallback<bool> ValueChanged { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public Guid Id { get; set; }


        protected override void OnInitialized()
        {
            Id = Guid.NewGuid();
        }

        public async Task Change(ChangeEventArgs e)
        {
            await ValueChanged.InvokeAsync((bool)e.Value);
        }
    }
}
