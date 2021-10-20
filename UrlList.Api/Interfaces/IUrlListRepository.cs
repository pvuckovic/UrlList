using UrlList.Api.Models;

namespace UrlList.Api.Interfaces
{
    public interface IUrlListRepository
    {
        public UrlListModel GetUrlList(string title);
        public void InsertUrlList(UrlListModel urlListModel);
    }
}
