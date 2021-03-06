﻿using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gunetberg.Web.Components
{
    public partial class CardComponent: ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public bool IsImageCard { get; set; }

        [Parameter]
        public bool OmitShadow { get; set; }

        [Parameter]
        public Action OnClick { get; set; }

    }
}
