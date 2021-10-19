using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using UrlList.Api.Entities;
using UrlList.Api.Interfaces;
using UrlList.Api.Models;

namespace UrlList.Api.MyDbContext
{
    public class UrlListRepository : IUrlListRepository
    {
        private readonly MyContext _context;

        public UrlListRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseInMemoryDatabase(databaseName:"UrlListDatabase");
            _context = new MyContext(optionsBuilder.Options);
        }

        public void InsertUrlList(UrlListModel urlListModel)
        {
            var urlListEntities = new List<UrlListEntity>();
            var urlItemsEntities = new List<UrlItemEntity>();

            foreach (var item in urlListModel.UrlItems) 
            {
                var urlItemId = Guid.NewGuid(); 

                urlItemsEntities.Add(new UrlItemEntity
                {
                    UrlTitle = item.Title,
                    UrlDescription = item.Description,
                    UrlItemId = urlItemId,
                    Url = item.Url
                });

                urlListEntities.Add(new UrlListEntity
                {
                    UrlItemId = urlItemId,
                    TitleId = urlListModel.Title,
                    Description = urlListModel.Description
                });
            }
            _context.UrlLists.AddRange(urlListEntities); 
            _context.UrlItems.AddRange(urlItemsEntities);

            _context.SaveChanges();
        }

        public UrlListModel GetUrlList(string title)
        {
            var urlListModel = new UrlListModel();

            var urlListEntities = _context.UrlLists.Where(x => x.TitleId == title).ToList();

            if (urlListEntities == null || urlListEntities.Count() == 0)
            {
                return null;
            }

            var urlItems = urlListEntities.Select(x => x.UrlItemId);
            var urlItemEntities = _context.UrlItems.Where(x => urlItems.Contains(x.UrlItemId));

            urlListModel.Title = urlListEntities.FirstOrDefault().TitleId;
            urlListModel.Description = urlListEntities.FirstOrDefault().Description;
            urlListModel.UrlItems = urlItemEntities
                .Select(x => new UrlItemModel
                {
                    Title = x.UrlTitle,
                    Description = x.UrlDescription,
                    Url = x.Url
                }).ToList();

            return urlListModel;
        }
    }
}
