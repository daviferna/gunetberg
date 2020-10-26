using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gunetberg.Web.Components
{
    public partial class MenuComponent: ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        private bool _isMenuVisible;
        public void ShowMenu()
        {
            _isMenuVisible = true;
        }

        public void HideMenu()
        {
            _isMenuVisible = false;
        }
    }
}
