using System.Collections.Generic;

namespace AC.ViewModels
{
    public class PagedResult<T> : PagedResultBase where T : class
    {
        public IReadOnlyList<T> Collection { get; set; }
        public PagedResult()
        {
            Collection = new List<T>();
        }
    }
}
