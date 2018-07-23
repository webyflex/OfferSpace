using OfferSpace.BL.Models;
using OfferSpace.DAL.Core;
using OfferSpace.BL.Interfaces;

namespace OfferSpace.DAL.Repositories
{
    public class RequestRepository : Repository<Request, long>, IRequestRepository
    {
        public RequestRepository(UnitOfWork uow) : base(uow)
        {
        }
    }
}
