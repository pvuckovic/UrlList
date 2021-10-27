using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text.Json;
using UrlList.Api.Controllers;
using UrlList.Api.Interfaces;
using UrlList.Api.Models;
using UrlList.Api.Requests;
using UrlList.Api.Responses;

namespace UnitTests
{
    [TestFixture]
    public class UrlListControlerTests
    {
        private IUrlListRepository _urlListRepository;
        private UrlListController _controler;

        [SetUp]
        public void Setup()
        {
            _urlListRepository = A.Fake<IUrlListRepository>();
            _controler = new UrlListController(_urlListRepository);
        }


        [Test]
        public void Post_WhenUrlListRequestNull_ShouldReturnBadRequest()
        {
            // Act
            var result = _controler.PostUrlList(null);

            // Assert
            var badRequest = result as BadRequestObjectResult;
            Assert.IsNotNull(badRequest);
            Assert.AreEqual("The object cant be null.", badRequest.Value);
        }

        [Test]
        public void Post_WhenTitleIsEmpty_ShouldReturnBadRequest()
        {
            var urlRequest = new UrlListRequest() {

                Title = string.Empty,
                Description = "TestCase",
                UrlItems = new List<UrlItemRequest>()
            };

            // Act
            var result = _controler.PostUrlList(urlRequest);

            // Assert
            var badRequest = result as BadRequestObjectResult;
            Assert.IsNotNull(badRequest);
            Assert.AreEqual("Title can not be empty.", badRequest.Value);
        }

        [Test]
        public void Post_WhenDescritpionIsEmpty_ShouldReturnBadRequest()
        {
            var urlRequest = new UrlListRequest()
            {

                Title = "Start_Practice",
                Description = string.Empty,
                UrlItems = new List<UrlItemRequest>()
            };

            // Act
            var result = _controler.PostUrlList(urlRequest);

            // Assert
            var badRequest = result as BadRequestObjectResult;
            Assert.IsNotNull(badRequest);
            Assert.AreEqual("Descritpion can not be empty.", badRequest.Value);
        }

        [Test]
        public void Post_WhenUrlItemsMustHave1Member_ShouldReturnBadRequest()
        {
            var urlRequests = new UrlListRequest()
            {
                Title = "Practice_Begin",
                Description = "Working",
                UrlItems = new List<UrlItemRequest>()
                {
                    
                }
            };

            // Act
            var result = _controler.PostUrlList(urlRequests);

            // Assert
            var badRequest = result as BadRequestObjectResult;
            Assert.IsNotNull(badRequest);
            Assert.AreEqual("Url list should have at least one member.", badRequest.Value);
        }

        [Test]
        public void Post_UrlListWithTitle_ShouldReturnOk()
        {
            var title = "Happy Monday";

            var urlTraget = new UrlListModel()
            {

                Title = "Practice_end",
                Description = "Lets Go",
                UrlItems = new List<UrlItemModel>()
                {
                    new UrlItemModel
                    {
                        Title = "instagram",
                        Description ="Social web",
                        Url = "www.instagram.com"
                    }
                }
            };

            var urlRequest = new UrlListRequest()
            {

                Title = "Practice_end",
                Description = "Lets Go",
                UrlItems = new List<UrlItemRequest>()
                {
                    new UrlItemRequest
                    {
                        UrlTitle = "instagram",
                        UrlDescription ="Social web",
                        Url = "www.instagram.com"
                    }
                }
            };

            A.CallTo(() => _urlListRepository.GetUrlList(title)).Returns(urlTraget);

            var result = _controler.PostUrlList(urlRequest);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual($"UrlList with title {urlRequest.Title} is already inserted.", okResult.Value);
                       
        }


        [Test]
        public void Get_WhenUrlListNotFound_ShouldReturnNotFound()
        {
            // Arrange
            var title = "not_found_title";
            A.CallTo(() => _urlListRepository.GetUrlList(title)).Returns(null);

            // Act
            var result = _controler.GetUrlList(title);

            // Assert
            var notFoundResult = result as NotFoundObjectResult;
            Assert.IsNotNull(notFoundResult);
            Assert.AreEqual($"Required url list with title {title} is not found.", notFoundResult.Value);
        }

        [Test]
        public void Get_TitleIsNullOrEmpty_ShouldReturnNotFound()
        {
            // Arrange
            var title = string.Empty;
            
           
            // Act
            var result = _controler.GetUrlList(title);

            // Assert
            var badRequestResult = result as BadRequestObjectResult;
            Assert.IsNotNull(badRequestResult);
            Assert.AreEqual("Title parametar is empty or null. Try again.", badRequestResult.Value);
        }

        [Test]
        public void Get_NewUrlListResponse_ReturnOK()
        {
            // Arrange
            var title = "practice";

            var newModel = new UrlList.Api.Models.UrlListModel()
            {

                Title = title,
                Description = "searching",
                UrlItems = new List<UrlList.Api.Models.UrlItemModel>()
                {
                    new UrlList.Api.Models.UrlItemModel
                    {
                        Url = "www.facebook.com",
                        Description = "fb",
                        Title = "Welcome"
                    }
                }
            };
 
            A.CallTo(() => _urlListRepository.GetUrlList(title)).Returns(newModel);

            // Act
            var result = _controler.GetUrlList(title);

            // Assert
            var okRequestResult = result as OkObjectResult;
            Assert.IsNotNull(okRequestResult);
            var response = okRequestResult.Value as UrlListResponse;

            Assert.AreEqual(newModel.Title, response.Title);
            Assert.AreEqual(newModel.Description, response.Description);
            Assert.AreEqual(newModel.UrlItems[0].Title, response.UrlItems[0].Title);
            Assert.AreEqual(newModel.UrlItems[0].Description, response.UrlItems[0].Description);
            Assert.AreEqual(newModel.UrlItems[0].Url, response.UrlItems[0].Url);

        }

    }
}