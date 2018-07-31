using Microsoft.AspNet.Identity;
using OfferSpace.BL.Interfaces;
using OfferSpace.BL.Interfaces.Services;
using OfferSpace.BL.Models;
using OfferSpace.DAL.Core;
using OfferSpace.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace OfferSpace.Web.Controllers.Api
{
  [Route("api/userrequest")]
  public class UserRequestController : ApiController
  {
    IRequestService _requstService;
    public UserRequestController(IRequestService requstService) {
      _requstService = requstService;
    }
    /*[HttpGet]
    public List<Request> GetRequests()
    {
      var catalog = new Catalog() { Title = "It" };
      var location = new Location() { Name = "Chernivtsi" };
      var request1 = new Request()
      {
        Title = "ios request",
        Catalog = catalog,
        Location = location,
        MinPrice = 20,
        MaxPrice = 200,
        Description = "ios request",
        CustomerId = 1,
        ScheduleFrom = DateTime.Now,
        ScheduleTo = DateTime.Now,
        Status = BL.Models.Enums.RequestStatus.New
      };
      var request2 = new Request()
      {
        Title = "android request",
        Catalog = catalog,
        Location = location,
        MinPrice = 10,
        MaxPrice = 2500,
        Description = "android request",
        CustomerId = 1,
        ScheduleFrom = DateTime.Now,
        ScheduleTo = DateTime.Now,
        Status = BL.Models.Enums.RequestStatus.New
      };
      var request3 = new Request()
      {
        Title = "kali request",
        Catalog = catalog,
        Location = location,
        MinPrice = 200,
        MaxPrice = 500,
        Description = "kali request",
        CustomerId = 1,
        ScheduleFrom = DateTime.Now,
        ScheduleTo = DateTime.Now,
        Status = BL.Models.Enums.RequestStatus.New
      };
      var request4 = new Request()
      {
        Title = "ubuntu request",
        Catalog = catalog,
        Location = location,
        MinPrice = 20,
        MaxPrice = 100,
        Description = "ubuntu request",
        CustomerId = 1,
        ScheduleFrom = DateTime.Now,
        ScheduleTo = DateTime.Now,
        Status = BL.Models.Enums.RequestStatus.New
      };
      var request5 = new Request()
      {
        Title = "windows request",
        Catalog = catalog,
        Location = location,
        MinPrice = 10,
        MaxPrice = 600,
        Description = "windows request",
        CustomerId = 1,
        ScheduleFrom = DateTime.Now,
        ScheduleTo = DateTime.Now,
        Status = BL.Models.Enums.RequestStatus.New
      };
      var request6 = new Request()
      {
        Title = "mint request",
        Catalog = catalog,
        Location = location,
        MinPrice = 20,
        MaxPrice = 350,
        Description = "mint request",
        CustomerId = 1,
        ScheduleFrom = DateTime.Now,
        ScheduleTo = DateTime.Now,
        Status = BL.Models.Enums.RequestStatus.New
      };
      var request7 = new Request()
      {
        Title = "site request",
        Catalog = catalog,
        Location = location,
        MinPrice = 50,
        MaxPrice = 206,
        Description = "site request",
        CustomerId = 1,
        ScheduleFrom = DateTime.Now,
        ScheduleTo = DateTime.Now,
        Status = BL.Models.Enums.RequestStatus.New
      };
      var request8 = new Request()
      {
        Title = "php request",
        Catalog = catalog,
        Location = location,
        MinPrice = 20,
        MaxPrice = 730,
        Description = "php request",
        CustomerId = 1,
        ScheduleFrom = DateTime.Now,
        ScheduleTo = DateTime.Now,
        Status = BL.Models.Enums.RequestStatus.New
      };
      var request9 = new Request()
      {
        Title = "c# request",
        Catalog = catalog,
        Location = location,
        MinPrice = 60,
        MaxPrice = 190,
        Description = "c# request",
        CustomerId = 1,
        ScheduleFrom = DateTime.Now,
        ScheduleTo = DateTime.Now,
        Status = BL.Models.Enums.RequestStatus.New
      };
      var request10 = new Request()
      {
        Title = "magento request",
        Catalog = catalog,
        Location = location,
        MinPrice = 50,
        MaxPrice = 300,
        Description = "magento request",
        CustomerId = 1,
        ScheduleFrom = DateTime.Now,
        ScheduleTo = DateTime.Now,
        Status = BL.Models.Enums.RequestStatus.New
      };
      var list = new List<Request>() { request1, request2, request3, request4, request5, request6, request7, request8, request9, request10 };
      return list;
    }*/
    [HttpGet]
    public List<Request> GetRequests()
    {
      var userId =RequestContext.Principal.Identity.GetUserId();
      var requests = _requstService.GetUserRequests(userId);
      return requests;
    }
  }
}
