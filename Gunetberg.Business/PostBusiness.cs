using Gunetberg.Cloud;
using Gunetberg.Domain;
using Gunetberg.Domain.Restrictions;
using Gunetberg.Exceptions;
using Gunetberg.Extension;
using Gunetberg.Infrastructure;
using Gunetberg.Types;
using Gunetberg.Types.Post;
using Gunetberg.Types.Section;
using System;
using System.Linq;

namespace Gunetberg.Business
{
    public class PostBusiness
    {
        private readonly Context _dbContext;
        private readonly BlobStorage _blobStorage;

        public PostBusiness(Context dbContext, BlobStorage blobStorage)
        {
            _dbContext = dbContext;
            _blobStorage = blobStorage;
        }

        public PFOCollection<PostDto> GetPosts(string title, DateTime? from, DateTime? to, string orderBy, bool orderByDescending, int page, int itemsPerPage)
        {
            var result = new PFOCollection<PostDto>();

            var posts = _dbContext.Posts.AsQueryable();

            #region filter
            if (!string.IsNullOrWhiteSpace(title))
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
                     HeaderImage = x.HeaderImage,
                     CreationDate = x.CreationDate,
                     AuthorAlias = x.Author.Alias
                 }).ToList();
            #endregion

            return result;
        }

        public CompletePostDto GetPost(long postId)
        {
            var post = _dbContext.Posts
                                 .Select(x =>
                                     new CompletePostDto
                                     {
                                         PostId = x.PostId,
                                         AuthorAlias = x.Author.Alias,
                                         HeaderImage = x.HeaderImage,
                                         CreationDate = x.CreationDate,
                                         Title = x.Title,
                                         Sections = x.Sections.Select(y => new SectionDto
                                         {
                                             SectionId = y.SectionId,
                                             CreationDate = y.CreationDate,
                                             Content = y.Content,
                                             Type = y.Type
                                         }).ToList()
                                     })
                                 .FirstOrDefault(x => x.PostId == postId);

            if (post == null)
            {
                throw new PostException(PostError.PostDoesNotExist);
            }

            return post;
        }

        public CreationResultDto<long> CreatePost(PostCreationDto newPost, long userId)
        {
            if (newPost == null)
            {
                throw new PostException(PostError.RequestIsEmpty);
            }
            if (string.IsNullOrWhiteSpace(newPost.Title))
            {
                throw new PostException(PostError.TitleIsNullOrWhitespace);
            }
            if (newPost.Title.Length > PostRestrictions.TitleMaxLength)
            {
                throw new PostException(PostError.TitleMaxLengthExceeded);
            }

            var utcNow = DateTime.UtcNow;
            var user = _dbContext.Users.FirstOrDefault(x => x.UserId == userId);

            if(user == null)
            {
                throw new UserException(UserError.DoesNotExist);
            }

            var sections = newPost.Sections?.Select(x => new Section {
                Type = (SectionType)x.SectionType, 
                Content = x.Content, 
                CreationDate = utcNow
            }).ToList();
            var post = new Post
            {
                Title = newPost.Title,
                CreationDate = DateTime.UtcNow,
                Author = user,
                Sections = sections,
                HeaderImage = newPost.HeaderImage                
            };

            _dbContext.Posts.Add(post);

            _dbContext.SaveChanges();

            return new CreationResultDto<long>
            {
                Id = post.PostId
            };
        }
   
    }
}
