using OfferSpace.BL.Models;
using OfferSpace.DAL.Core;
using OfferSpace.BL.Interfaces;

namespace OfferSpace.DAL.Repositories
{
    public class CustomerRepository : Repository<UserProfile, long>, ICustomerRepository
    {
        public CustomerRepository(UnitOfWork uow) : base(uow)
        {
        }
    }
}
