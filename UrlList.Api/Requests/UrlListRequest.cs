using System.Collections.Generic;

namespace UrlList.Api.Requests
{
    public class UrlListRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<UrlItemRequest> UrlItems { get; set; }
    }

    public class UrlItemRequest
    {
        public string Url { get; set; }
        public string UrlDescription { get; set; }
        public string UrlTitle { get; set; }
    }
}
