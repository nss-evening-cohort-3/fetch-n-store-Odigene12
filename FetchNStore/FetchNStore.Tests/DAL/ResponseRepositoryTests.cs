using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using FetchNStore.Models;
using FetchNStore.DAL;

namespace FetchNStore.Tests.DAL
{
    [TestClass]
    public class ResponseRepositoryTests
    {
        Mock<ResponseContext> myContext { get; set; }
        Mock<DbSet<Response>> mockResponses { get; set; }
        List<Response> ResponseList = new List<Response>();

        ResponseRepository repo { get; set; }


        public void ConnectingToDatabase()
        {
            var queryResponses = ResponseList.AsQueryable();

            //Lie to LINQ make it think that our new Queryable List is a Database table.
            mockResponses.As<IQueryable<Response>>().Setup(m => m.Provider).Returns(queryResponses.Provider);
            mockResponses.As<IQueryable<Response>>().Setup(m => m.Expression).Returns(queryResponses.Expression);
            mockResponses.As<IQueryable<Response>>().Setup(m => m.ElementType).Returns(queryResponses.ElementType);
            mockResponses.As<IQueryable<Response>>().Setup(m => m.GetEnumerator()).Returns(() => (queryResponses.GetEnumerator()));

            //Here, I am setting up the Mock Context to return my DbSet.
            myContext.Setup(c => c.Responses).Returns(mockResponses.Object);
        }

        [TestInitialize]

        public void Initialize()
        {
            myContext = new Mock<ResponseContext>();
            mockResponses = new Mock<DbSet<Response>>();
            ResponseList = new List<Response>()
            {
                new Response { HTTPMethod = "Get", StatusCode = 400, URL = "http://somewebsite.com", ResponseTime = 1234554974 },
            };

            repo = new ResponseRepository(myContext.Object);
            ConnectingToDatabase();
        }

        [TestMethod]
        public void CanIMakeAnInstanceOfResponseClass()
        {
            Mock<DbSet<Response>> Response = new Mock<DbSet<Response>>();

            Assert.IsNotNull(Response);
        }

        [TestMethod]
        public void CanIMakeAnInstanceOfRepository()
        {
            Mock<ResponseRepository> repo = new Mock<ResponseRepository>(myContext.Object);

            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void CanIGetMyResponses()
        {
            List<Response> myResponses = repo.GetResponses();

            Assert.AreEqual(myResponses.Count, 1);
        }

        [TestMethod]
        public void CanIGetResponseByURL()
        {
            Response newResponse = new Response() { HTTPMethod = "Post", StatusCode = 200, ResponseTime = 459653214, URL = "http://facebook.com" };

            ResponseList.Add(newResponse);

            Response foundResponse = repo.GetResponses("http://facebook.com");

            Assert.AreEqual(foundResponse.URL, "http://facebook.com");
        }

        [TestMethod]
        public void CanIAddANewResponse()
        {
            Response newResponse = new Response() { HTTPMethod = "Post", StatusCode = 200, ResponseTime = 459653214, URL = "http://facebook.com" };

            ResponseList.Add(newResponse);

            List<Response> myResponses = repo.GetResponses();

            Assert.AreEqual(myResponses.Count, 2); 
        }
    }
}
