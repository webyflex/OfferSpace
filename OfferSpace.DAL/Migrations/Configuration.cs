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
            context.Locations.AddOrUpdate(i => i.Name,
                new Location
                {
                    Name = "aa"
                }
            );
        }
    }
}
