using System;
using System.Collections.Generic;
using System.Text;

namespace Gunetberg.Types
{
    public class OrderedItemRequest
    {
        public string OrderedBy { get; set; }
        public bool IsOrderedDescending { get; set; }
    }
}
