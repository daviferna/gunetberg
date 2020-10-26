using System;

namespace Gunetberg.Configuration
{
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        public string ProfilePictureUrl => @"https://gunetbergstorage.blob.core.windows.net/profilepictures/{0}.png";

        public string ProfilePictureDefaultUrl => @"https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_960_720.png";

        public string GetProfilePictureUrl(Guid? profilePicture)
        {
            return profilePicture.HasValue? string.Format(ProfilePictureUrl, profilePicture): ProfilePictureDefaultUrl;
        }
    }
}
