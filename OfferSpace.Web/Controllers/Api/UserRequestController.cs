using OfferSpace.BL.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace OfferSpace.Web.Controllers.Api
{
    [Route("api/userrequest")]
    public class UserRequestController : ApiController
    {
        [HttpGet]
        public List<Request> GetRequests()
        {
            return new List<Request>() {
                new Request() { Id = 1, Title="Title 1", Description = "Test 1 description" },
                new Request() { Id = 2, Title="Title 2", Description = "Test 2 description" },
                new Request() { Id = 3, Title="Title 3", Description = "Test 3 description" },
                new Request() { Id = 4, Title="Title 4", Description = "Test 4 description" },
                new Request() { Id = 5, Title="Title 5", Description = "Test 5 description" },
                new Request() { Id = 6, Title="Title 6", Description = "Test 6 description" },
                new Request() { Id = 7, Title="Title 7", Description = "Test 7 description" },
                new Request() { Id = 8, Title="Title 8", Description = "Test 8 description" },
                new Request() { Id = 9, Title="Title 9", Description = "Test 9 description" },
                new Request() { Id = 10, Title="Title 10", Description = "Test 10 description" }
            };
        }  
    }
}
