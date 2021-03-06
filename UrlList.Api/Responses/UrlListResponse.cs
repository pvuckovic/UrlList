using System.Collections.Generic;

namespace UrlList.Api.Responses
{
    public class UrlListResponse
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<UrlItem> UrlItems { get; set; }
    }

    public class UrlItem
    {
        public string Url { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
}
