using System;
using System.ComponentModel.DataAnnotations;

namespace UrlList.Api.Entities
{
    public class UrlListEntity
    {
        [Key]
        public string TitleId { get; set; }
        public string Description { get; set; }
        public Guid UrlItemId { get; set; }
    }
}
