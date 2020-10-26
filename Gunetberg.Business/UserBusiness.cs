using Gunetberg.Cloud;
using Gunetberg.Configuration;
using Gunetberg.Domain;
using Gunetberg.Domain.Restrictions;
using Gunetberg.Exceptions;
using Gunetberg.Extension;
using Gunetberg.Helpers;
using Gunetberg.Infrastructure;
using Gunetberg.Types;
using Gunetberg.Types.User;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Gunetberg.Business
{
    public class UserBusiness
    {
        private readonly Context _dbContext;
        private readonly BlobStorage _blobStorage;
        private readonly ApplicationConfiguration _applicationConfiguration;

        public UserBusiness(Context dbContext, BlobStorage blobStorage, ApplicationConfiguration applicationConfiguration)
        {
            _dbContext = dbContext;
            _blobStorage = blobStorage;
            _applicationConfiguration = applicationConfiguration;
        }

        public CreationResultDto<long> CreateUser(UserCreationDto newUser)
        {
            #region validation
            if (newUser == null)
            {
                throw new UserException(UserError.RequestIsEmpty);
            }
            if (string.IsNullOrWhiteSpace(newUser.Email))
            {
                throw new UserException(UserError.EmailIsNullOrWhitespace);
            }
            if (!newUser.Email.HasEmailFormat())
            {
                throw new UserException(UserError.EmailIsNotValid);
            }
            if (newUser.Email.Length > UserRestrictions.EmailMaxLength)
            {
                throw new UserException(UserError.EmailMaxLengthExceeded);
            }
            if (string.IsNullOrWhiteSpace(newUser.Alias))
            {
                throw new UserException(UserError.AliasIsNullOrWhitespace);
            }
            if (newUser.Alias.Length > UserRestrictions.AliasMaxLength)
            {
                throw new UserException(UserError.AliasMaxLengthExceeded);
            }
            if (string.IsNullOrWhiteSpace(newUser.Password))
            {
                throw new UserException(UserError.PasswordIsNullOrWhitespace);
            }
            if (newUser.Password.Length > UserRestrictions.PasswordMaxLength)
            {
                throw new UserException(UserError.PasswordMaxLengthExceeded);
            }
            if (_dbContext.Users.FirstOrDefault(x => x.Email == newUser.Email) != null)
            {
                throw new UserException(UserError.EmailAlreadyExists);
            }
            if (_dbContext.Users.FirstOrDefault(x => x.Alias == newUser.Alias) != null)
            {
                throw new UserException(UserError.AliasAlreadyExists);
            }
            #endregion

            //Create
            var user = new User
            {
                Email = newUser.Email,
                Alias = newUser.Alias,
                CreationDate = DateTime.UtcNow,
                Password = PasswordHelper.GetHashFromString(newUser.Password),
                Role = Role.User
            };

            _dbContext.Users.Add(user);

            if (_dbContext.SaveChanges() != 1)
            {
                throw new UserException(UserError.NotCreated);
            }

            return new CreationResultDto<long>
            {
                Id = user.UserId
            };
        }

        public UserDetail GetUser(long userId)
        {
            var user = _dbContext.Users.Where(x => x.UserId == userId).Select(x => new UserDetail
            {
                Alias = x.Alias,
                Email = x.Email,
                UserId = x.UserId,
                ProfilePicture = _applicationConfiguration.GetProfilePictureUrl(x.ProfilePicture)
            }).FirstOrDefault();

            if (user == null)
            {
                throw new UserException(UserError.DoesNotExist);
            }

            return user;

        }

        public async Task<CreationResultDto<string>> UpdateProfilePicture(long userId, UserUpdateProfilePicture userUpdateProfilePhoto)
        {

            if (string.IsNullOrWhiteSpace(userUpdateProfilePhoto.ProfilePicture))
            {
                throw new UserException(UserError.ProfilePhotoIsEmpty);
            }

            var user = _dbContext.Users.FirstOrDefault(x => x.UserId == userId);
            if (user == null)
            {
                throw new UserException(UserError.DoesNotExist);
            }
            user.ProfilePicture = Guid.NewGuid();

            var profilePhoto = Convert.FromBase64String(userUpdateProfilePhoto.ProfilePicture);
                     
            await _blobStorage.Upload(profilePhoto, $"{user.ProfilePicture}.png");

            _dbContext.SaveChanges();

            return new CreationResultDto<string>
            {
                Id = _applicationConfiguration.GetProfilePictureUrl(user.ProfilePicture)
            };
        }

        public UserSummary GetUserSummary(long userId)
        {
            var userSummary = _dbContext.Users.Where(x => x.UserId == userId).Select(x => new UserSummary
            {
                CreationDate = x.CreationDate.ToUniversalTime(),
                PostCount = x.Posts.Count,
                CommentaryCount = x.Commentaries.Count
            }).FirstOrDefault();

            if (userSummary == null)
            {
                throw new UserException(UserError.DoesNotExist);
            }

            return userSummary;
        }
    }
}
