using Gunetberg.Extension;
using Gunetberg.Infrastructure;
using Gunetberg.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gunetberg.Business
{
    public class PostBusiness
    {
        private readonly Context _dbContext;

        public PostBusiness(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public PFOCollection<PostDto> GetPosts(string title, DateTime? from, DateTime? to, string orderBy, bool orderByDescending, int page, int itemsPerPage)
        {
            var result = new PFOCollection<PostDto>();

            var posts = _dbContext.Posts.AsQueryable();

            #region filter
            if (!title.IsNullOrWhitespace())
            {
                posts = posts.Where(x => x.Title.Contains(title));
            }
            if (from.HasValue)
            {
                posts = posts.Where(x => x.CreationDate >= from.Value);
            }
            if (to.HasValue)
            {
                posts = posts.Where(x => x.CreationDate <= from.Value);
            }

            #endregion

            #region order
            switch (orderBy)
            {
                case "Title":
                    posts = orderByDescending ? posts.OrderByDescending(x => x.Title) : posts.OrderBy(x => x.Title);
                    break;
                case "CreationDate":
                    posts = orderByDescending ? posts.OrderByDescending(x => x.CreationDate) : posts.OrderBy(x => x.CreationDate);
                    break;
                default:
                    posts = orderByDescending ? posts.OrderByDescending(x => x.CreationDate) : posts.OrderBy(x => x.CreationDate);
                    break;
            }

            #endregion

            #region pagination
            result.ItemsPerPage = itemsPerPage > 10 ? itemsPerPage : 50;
            result.TotalPages = (posts.Count() / result.ItemsPerPage) + 1;
            result.Page = (page > result.TotalPages || page < 1) ? 1 : result.TotalPages;
            var itemsToSkip = (result.Page - 1) * result.ItemsPerPage;
            var itemsToTake = (posts.Count() - itemsToSkip < result.ItemsPerPage) ? posts.Count() - itemsToSkip : result.ItemsPerPage;
            result.Items = (itemsToSkip > 0 ? posts.Skip(itemsToSkip) : posts).Take(itemsToTake).Select(x =>
                 new PostDto
                 {
                     PostId = x.PostId,
                     Title = x.Title,
                     CreationDate = x.CreationDate,
                     AuthorAlias = x.Author.Alias
                 }).ToList();
            #endregion

            return result;
        }


    }
}
