using Gunetberg.Types.Post;
using Gunetberg.Web.Providers;
using Gunetberg.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gunetberg.Web.Pages
{
    public partial class PostPage : ComponentBase
    {
        [Inject]
        private PostService _postService { get; set; }

        [Parameter]
        public long PostId { get; set; }

        public CompletePostDto Post { get; set; }



        protected override async Task OnInitializedAsync()
        {
            Post = await _postService.GetPost(PostId);
        }


        protected override async Task OnParametersSetAsync()
        {
            Post = await _postService.GetPost(PostId);
        }


    }
}
