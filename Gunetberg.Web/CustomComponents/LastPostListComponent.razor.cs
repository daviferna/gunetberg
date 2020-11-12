using Gunetberg.Types.Post;
using Gunetberg.Web.Providers;
using Gunetberg.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gunetberg.Web.CustomComponents
{
    public partial class LastPostListComponent: ComponentBase
    {
        [Inject]
        private LateralBarProvider _lateralBarProvider { get; set; }

        [Inject]
        private NavigationManager _navigationManager { get; set; }

        [Inject]
        private PostService _postService { get; set; }
 
        public ICollection<PostDto> LastPosts { get; set; }

        protected override async Task OnInitializedAsync()
        {
            LastPosts = await _postService.GetLastPosts();
        }

        public void LoadPost(long postId)
        {
            _lateralBarProvider.Close();
            _navigationManager.NavigateTo($"post/{postId}");
        }
    }
}
