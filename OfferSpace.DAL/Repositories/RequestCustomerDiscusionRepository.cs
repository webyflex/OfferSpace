using OfferSpace.BL.Models;
using OfferSpace.DAL.Core;
using OfferSpace.BL.Interfaces;

namespace OfferSpace.DAL.Repositories
{
    public class RequestCustomerDiscusionRepository : Repository<RequestCustomerDiscusion, long>, IRequestCustomerDiscusionRepository
    {
        public RequestCustomerDiscusionRepository(UnitOfWork uow) : base(uow)
        {
        }
    }
}
