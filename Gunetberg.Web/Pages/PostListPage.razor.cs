using Gunetberg.Types;
using Gunetberg.Types.Post;
using Gunetberg.Web.BaseComponents;
using Gunetberg.Web.Components;
using Gunetberg.Web.Providers;
using Gunetberg.Web.Services;
using Gunetberg.Web.Types;
using Microsoft.AspNetCore.Components;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Gunetberg.Web.Pages
{
    public partial class PostListPage: ComponentBase
    {
        [Inject]
        private LocalizationProvider _localizationProvider { get; set; }

        [Inject]
        private PostService _postService { get; set; }

        [Inject]
        private NavigationManager _navigationManager { get; set; }

        public PFOCollection<PostDto> Posts;

        public PostDto FeaturedPost;

        protected override async Task OnInitializedAsync()
        {
            Posts = await _postService.GetPostList();
            FeaturedPost = await _postService.GetFeaturedPost();  
        }

        public void LoadPost(long postId)
        {       
            _navigationManager.NavigateTo($"post/{postId}");
        }

    }
}
