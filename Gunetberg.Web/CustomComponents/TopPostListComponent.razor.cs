using Gunetberg.Types.Post;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gunetberg.Web.CustomComponents
{
    public partial class TopPostListComponent: ComponentBase
    {
        public PostTopDto[] TopPosts { get; set; }

        protected override void OnInitialized()
        {
            TopPosts = new PostTopDto[]
            {
                new PostTopDto{PostId=1, Title="Post de prueba que es un poquito más largo", CreationDate = DateTime.UtcNow },
                new PostTopDto{PostId=2, Title="Post de prueba que es cortito", CreationDate = DateTime.UtcNow },
                new PostTopDto{PostId=3, Title="Post de prueba que no me apetece mucho poner porque se sale", CreationDate = DateTime.UtcNow },
                new PostTopDto{PostId=4, Title="Post de prueba 4", CreationDate = DateTime.UtcNow },
                new PostTopDto{PostId=5, Title="Post de prueba 5", CreationDate = DateTime.UtcNow },

            };
        }
    }
}
