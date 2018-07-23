using OfferSpace.BL.Models;
using OfferSpace.DAL.Core;
using OfferSpace.BL.Interfaces;

namespace OfferSpace.DAL.Repositories
{
    public class LocationRepository : Repository<Location, long>, ILocationRepository
    {
        public LocationRepository(UnitOfWork uow) : base(uow)
        {
        }
    }
}
