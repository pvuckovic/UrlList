using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using UrlList.Api.Interfaces;
using UrlList.Api.MyDbContext;
using UrlList.Api.Requests;
using UrlList.Api.Responses;

namespace UrlList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlListController : ControllerBase
    {
        private readonly IUrlListRepository _urlListRepository;

        public UrlListController(IUrlListRepository urlListRepository)
        {
            _urlListRepository = urlListRepository;
        }

        [HttpGet]
        [Route("{title}")]
        public ActionResult GetUrlList(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return BadRequest("Title parametar is empty or null. Try again.");
            }

            var targetUrlList = _urlListRepository.GetUrlList(title);

            if (targetUrlList == null)
            {
                return NotFound($"Required url list with title {title} is not found.");
            }

            var result = new UrlListResponse
            {
                Title = targetUrlList.Title,
                Description = targetUrlList.Description,
                UrlItems = targetUrlList.UrlItems.Select(x => new UrlItem
                {
                    Title = x.Title,
                    Description = x.Description,
                    Url = x.Url
                }).ToList()
            };
            return Ok(result);
        }

        [HttpPost]
        [Route("posturllist")]
        public ActionResult PostUrlList([FromBody] UrlListRequest urlListRequest)
        {
            if (urlListRequest == null)
            {
                return BadRequest("The object cant be null.");
            }

            if (string.IsNullOrEmpty(urlListRequest.Title))
            {
                return BadRequest("Title can not be empty.");
            }

            if (string.IsNullOrEmpty(urlListRequest.Description))
            {
                return BadRequest("Descritpion can not be empty.");
            }

            if (urlListRequest.UrlItems != null && urlListRequest.UrlItems.Count == 0)
            {
                return BadRequest("Url list should have at least one member.");
            }

            var targetUrlList = _urlListRepository.GetUrlList(urlListRequest.Title);

            if (targetUrlList == null)
            {
                try
                {
                    _urlListRepository.InsertUrlList(new Models.UrlListModel
                    {
                        Description = urlListRequest.Description,
                        Title = urlListRequest.Title,
                        UrlItems = urlListRequest.UrlItems.Select(x => new Models.UrlItemModel
                        {
                            Title = x.UrlTitle,
                            Description = x.UrlDescription,
                            Url = x.Url
                        }).ToList()
                    });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Exception occured. Details: {ex.Message}");
                }
                return Ok($"UrlList with title {urlListRequest} is inserted.");
            }
            else
            {
                return Ok($"UrlList with title {urlListRequest} is already inserted.");
            }
        }
    }
}