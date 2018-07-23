using OfferSpace.BL.Models;
using OfferSpace.DAL.Core;
using OfferSpace.BL.Interfaces;

namespace OfferSpace.DAL.Repositories
{
    public class RequestCustomerRepository : Repository<RequestCustomer, long>, IRequestCustomerRepository
    {
        public RequestCustomerRepository(UnitOfWork uow) : base(uow)
        {
        }
    }
}
