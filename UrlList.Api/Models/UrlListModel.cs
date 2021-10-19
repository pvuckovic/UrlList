using System.Collections.Generic;

namespace UrlList.Api.Models
{
    public class UrlListModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<UrlItemModel> UrlItems { get; set; }
    }

    public class UrlItemModel
    {
        public string Url { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
}
