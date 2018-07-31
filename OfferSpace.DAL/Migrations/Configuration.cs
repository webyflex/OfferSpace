namespace OfferSpace.DAL.Migrations
{
    using OfferSpace.BL.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OfferSpace.DAL.Core.OfferSpaceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "OfferSpace.DAL.Core.OfferSpaceContext";
        }

        protected override void Seed(OfferSpace.DAL.Core.OfferSpaceContext context)
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
            context.Catalogs.AddOrUpdate(catalog);
            context.Locations.AddOrUpdate(location);
            context.Requests.AddOrUpdate(request1);
            context.Requests.AddOrUpdate(request2);
            context.Requests.AddOrUpdate(request3);
            context.Requests.AddOrUpdate(request4);
            context.Requests.AddOrUpdate(request5);
            context.Requests.AddOrUpdate(request6);
            context.Requests.AddOrUpdate(request7);
            context.Requests.AddOrUpdate(request8);
            context.Requests.AddOrUpdate(request9);
            context.Requests.AddOrUpdate(request10);

        }
    }
}
