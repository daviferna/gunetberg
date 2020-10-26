using Gunetberg.Types.Section;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gunetberg.Web.CustomComponents
{
    public partial class PostSectionComponent: ComponentBase
    {
        [Parameter]
        public ICollection<SectionDto> Sections { get; set; }
    }
}
