using System;
using System.ComponentModel.DataAnnotations;

namespace UrlList.Api.Entities
{
    public class UrlItemEntity
    {
        [Key]
        public Guid UrlItemId { get; set; }
        public string UrlDescription { get; set; }
        public string UrlTitle { get; set; }
        public string Url { get; set; }
    }
}
