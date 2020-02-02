using System.Collections.Generic;

namespace Gunetberg.Types
{
    public class PFOCollection<T>
    {
        public int Page { get; set; }
        public int TotalPages { get; set; }
        public int TotalItemCount { get; set; }
        public int ItemsPerPage { get; set; }
        public string OrderedBy { get; set; }
        public bool IsOrderedDescending { get; set; }
        public ICollection<T> Items { get; set; }
        public ICollection<string> FilteredBy { get; set; }
    }
}
