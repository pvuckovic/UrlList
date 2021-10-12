using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlList.Api.Responses
{
    public class UrlListResponse
    {
        public class UrlListRequest
        {

            public string Title { get; set; }


            public string Description { get; set; }

            public List<UrlItem> UrlItems { get; set; }
        }

        public class UrlItem
        {
            // [Key]
            //[DataType(DataType.Text)]
            public string Url { get; set; }

            //[Required]
            //[DataType(DataType.Text)]
            public string Description { get; set; }

            //[StringLength(50, MinimumLength = 10,
            //ErrorMessage = "Description should be minimum 10 characters and a maximum of 50 characters")]
            //[DataType(DataType.Text)]
            public string Title { get; set; }
        }
    }
}
