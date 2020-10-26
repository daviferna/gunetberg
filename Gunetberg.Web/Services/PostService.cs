using Gunetberg.Types;
using Gunetberg.Types.Post;
using Gunetberg.Web.Providers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gunetberg.Web.Services
{
    public class PostService:HttpService
    {

        public PostService(HttpClientProvider httpClientProvider) : base(httpClientProvider)
        {
  
        }

        public async Task<PFOCollection<PostDto>> GetPostList()
        {     
            return await GetAsync<PFOCollection<PostDto>>("api/post/list");
        }

        public async Task<PostDto> GetFeaturedPost()
        {
            return await GetAsync<PostDto>("api/post/featured");
        }

        public async Task<ICollection<PostDto>> GetLastPosts()
        {
            return await GetAsync<ICollection<PostDto>>($"api/post/last");
        }

        public async Task<CompletePostDto> GetPost(long postId)
        {
           return await GetAsync<CompletePostDto>($"api/post/get?postId={postId}");
        }
        
    }
}
