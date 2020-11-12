using Gunetberg.Cloud;
using Gunetberg.Configuration;
using Gunetberg.Domain;
using Gunetberg.Domain.Restrictions;
using Gunetberg.Exceptions;
using Gunetberg.Extension;
using Gunetberg.Helpers;
using Gunetberg.Infrastructure;
using Gunetberg.Types;
using Gunetberg.Types.Author;
using Gunetberg.Types.Post;
using Gunetberg.Types.Section;
using Gunetberg.Types.Tag;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Gunetberg.Business
{
    public class PostBusiness
    {
        private readonly Context _dbContext;
        private readonly BlobStorage _blobStorage;
        private readonly ApplicationConfiguration _applicationConfiguration;


        public PostBusiness(Context dbContext, BlobStorage blobStorage, ApplicationConfiguration applicationConfiguration)
        {
            _dbContext = dbContext;
            _blobStorage = blobStorage;
            _applicationConfiguration = applicationConfiguration;
        }

        public ICollection<AutocompletePostDto> GetAutocompletePosts(string title)
        {
            return _dbContext.Posts.Where(x => x.Title.Contains(title))
                                    .Select(x => new AutocompletePostDto
                                    {
                                        PostId = x.PostId,
                                        Title = x.Title
                                    })
                                    .Take(10)
                                    .ToList();
        }

        public PFOCollection<PostDto> GetPosts(string title, DateTime? from, DateTime? to, string orderBy, bool orderByDescending, int page, int? itemsPerPage)
        {
            var result = new PFOCollection<PostDto>();
            result.FilteredBy = new List<string>();

            var posts = _dbContext.Posts.AsQueryable();

            #region filter
            if (!string.IsNullOrWhiteSpace(title))
            {
                posts = posts.Where(x => x.Title.Contains(title));
                result.FilteredBy.Add("title");
            }
            if (from.HasValue)
            {
                posts = posts.Where(x => x.CreationDate >= from.Value);
                result.FilteredBy.Add("from");
            }
            if (to.HasValue)
            {
                posts = posts.Where(x => x.CreationDate <= from.Value);
                result.FilteredBy.Add("to");
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
            result.ItemsPerPage = itemsPerPage?? 10;
            result.TotalPages = (int)Math.Ceiling(posts.Count() / (decimal)result.ItemsPerPage);
            result.Page = ( page > result.TotalPages || page < 1) ? 1 : result.TotalPages;
            var itemsToSkip = (result.Page - 1) * result.ItemsPerPage;
            var itemsToTake = (posts.Count() - itemsToSkip < result.ItemsPerPage) ? posts.Count() - itemsToSkip : result.ItemsPerPage;
            result.Items = (itemsToSkip > 0 ? posts.Skip(itemsToSkip) : posts).Take(itemsToTake).Select(x =>
                 new PostDto
                 {
                     PostId = x.PostId,
                     Title = x.Title,
                     HeaderImage = x.HeaderImage,
                     CreationDate = x.CreationDate.ToUniversalTime(),
                     Author = new AuthorDto
                     {
                         Alias = x.Author.Alias
                     },
                     Description = x.Sections.Where(x => x.Type == SectionType.Markdown).Select(y => y.Content.Substring(0, 150)).FirstOrDefault() + "..."
                 }).ToList();
            #endregion

            return result;
        }

        public PostDto GetFeaturedPost()
        {
            var x = _dbContext.Posts.Where(x => x.FeaturedDate.HasValue)
                .OrderByDescending(x => x.FeaturedDate)
                .Select(x => new PostDto
                {
                    PostId = x.PostId,
                    Author = new AuthorDto
                    {
                        Alias = x.Author.Alias,
                        ProfilePicture = _applicationConfiguration.GetProfilePictureUrl(x.Author.ProfilePicture)
                    },
                    CreationDate = x.CreationDate,
                    Description = x.Sections.FirstOrDefault(x => x.Type == SectionType.Markdown).Content.Substring(0, 150),
                    HeaderImage = x.HeaderImage,
                    Title = x.Title
                }).FirstOrDefault();

            return x;
        }

        public CompletePostDto GetPost(long postId)
        {
            var post = _dbContext.Posts
                                 .Select(x =>
                                     new CompletePostDto
                                     {
                                         PostId = x.PostId,
                                         HeaderImage = x.HeaderImage,
                                         CreationDate = x.CreationDate.ToUniversalTime(),
                                         Title = x.Title,
                                         Author = new AuthorDto
                                         {
                                             Alias = x.Author.Alias,
                                             Description = x.Author.Description,
                                             ProfilePicture = _applicationConfiguration.GetProfilePictureUrl(x.Author.ProfilePicture)
                                         },
                                         Sections = x.Sections.Select(y => new SectionDto
                                         {
                                             SectionId = y.SectionId,
                                             CreationDate = y.CreationDate,
                                             Content = y.Content,
                                             Type = y.Type.ToString()
                                         }).ToList(),
                                         Tags = x.PostTags.Select(y => new TagDto
                                         {
                                             TagId = y.TagId,
                                             Name = y.Tag.Name
                                         }).ToList()
                                     })
                                 .FirstOrDefault(x => x.PostId == postId);

            if (post == null)
            {
                throw new PostException(PostError.PostNotFound);
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

            if (user == null)
            {
                throw new UserException(UserError.DoesNotExist);
            }

            var sections = newPost.Sections?.Select(x => new Section
            {
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

        public byte[] DownloadPost(long postId)
        {
            var post = _dbContext.Posts
                .Include(x => x.Sections)
                .Include(x => x.Author)
                .FirstOrDefault(x => x.PostId == postId);

            if (post == null)
            {
                throw new PostException(PostError.PostNotFound);
            }

            return DownloaderHelper.GetInstance().GeneratePostPdf(post.Title, post.Author.Alias, post.CreationDate, post.Sections.Select(x => x.Content));
        }
    }
}
