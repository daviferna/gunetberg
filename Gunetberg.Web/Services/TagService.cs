using Gunetberg.Types;
using Gunetberg.Types.Post;
using Gunetberg.Types.Tag;
using Gunetberg.Web.Providers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gunetberg.Web.Services
{
    public class TagService:HttpService
    {

        public TagService(HttpClientProvider httpClientProvider) : base(httpClientProvider)
        {
  
        }

        public async Task<ICollection<TagDto>> GetTags()
        {     
            return await GetAsync<ICollection<TagDto>>("api/tag/list");
        }


        
    }
}
