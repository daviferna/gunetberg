using Gunetberg.Types.Tag;
using Gunetberg.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gunetberg.Web.CustomComponents
{
    public partial class CategoriesComponent: ComponentBase
    {
        [Inject]
        private TagService _tagService { get; set; }

        public ICollection<TagDto> Tags;

        protected override async Task OnInitializedAsync()
        {
            Tags = await _tagService.GetTags();
        }
    }
}
