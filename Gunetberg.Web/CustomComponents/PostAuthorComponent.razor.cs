using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gunetberg.Web.CustomComponents
{
    public partial class PostAuthorComponent:ComponentBase
    {
        [Parameter]
        public string Alias { get; set; }
        
        [Parameter]
        public string ProfilePicture { get; set; }

        [Parameter]
        public string Description { get; set; }

    }
}
