using System;
using System.Collections.Generic;
using System.Text;

namespace Gunetberg.Types
{
    public class PaginatedItemRequest
    {
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
    }
}
