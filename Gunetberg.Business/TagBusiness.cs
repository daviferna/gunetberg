using Gunetberg.Infrastructure;
using Gunetberg.Types.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gunetberg.Business
{
    public class TagBusiness
    {
        private readonly Context _dbContext;

        public TagBusiness(Context dbContext)
        {
            _dbContext = dbContext;
        }


        public ICollection<TagDto> GetTags()
        {
            return _dbContext.Tags.Select(x => new TagDto
            {
                TagId = x.TagId,
                Name = x.Name
            }).ToList();
        }
    }
}
