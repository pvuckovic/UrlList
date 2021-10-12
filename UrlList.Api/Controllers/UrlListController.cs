using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.Json;
using UrlList.Api.Repositories;
using UrlList.Api.Requests;
using UrlList.Api.Responses;

namespace UrlList.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UrlListController : ControllerBase
    {
       

        [HttpGet]

        public ActionResult GetUrlList([FromQuery] string? title)
        {
            //TODO AT Check title parametar is null or empty if not correct return bad request with message
            //var result = GetUrlList(title);

            if (string.IsNullOrEmpty(title))
            {
                return BadRequest("Title parametar is empty or null. Try again.");
            }


            //If required url list exist return Ok otherwise return NotFound 404            
            var urlLists = new UrlListResponse();
                       
            if (urlLists == null)
            {
                return NotFound();
            }
                                                                                           
            //TODO FJ If title parametar is fine than call repository to get urlList
            var urlList = new UrlListResponse(); //temp variable should be fill with real data


            return Ok(urlList);
        }



        [HttpPost]

        public ActionResult PostUrlList([FromBody] UrlListRequest urlRequest)
        {

            //TODO AT Validate urllist request object            
            if (urlRequest == null)
            {
                return BadRequest("The object cant be null.");
            }
            
            //Validate that all fields are not null or empty
            //Title and description cant be null or empty and UrlItem List should have at least one member
            if (string.IsNullOrEmpty(urlRequest.Title))
            {
                return BadRequest("Title can not be empty.");
            }

            if (string.IsNullOrEmpty(urlRequest.Description))
            {
                return BadRequest("Descritpion can not be empty.");
            }

            if (urlRequest.UrlItems != null && urlRequest.UrlItems.Count == 0)
            {
                return BadRequest("Url list should have at least one member.");
            }
                      
            //Before repository implemented try recording data into text file

            string jsonString = JsonSerializer.Serialize(urlRequest);

            using (StreamWriter writer = new StreamWriter("UrlListProject.txt", true)) //// true to append data to the file
            {
                writer.WriteLine(jsonString);
            }

            //TODO FJ If all checks passed call repository to insert URL List
            //Add try/catche block around insert operation
            //If there is exception return error message otherwise return Ok

            return Ok();
        }
       
    }
    
}