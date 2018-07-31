using OfferSpace.BL.Models;
using OfferSpace.DAL.Core;
using OfferSpace.BL.Interfaces;
using System.Linq;

namespace OfferSpace.DAL.Repositories
{
    public class CustomerRepository : Repository<UserProfile, long>, ICustomerRepository
    {
        public CustomerRepository(UnitOfWork uow) : base(uow)
        {
          
        }

        public UserProfile FindUserProfileById(string id)
        {
            OfferSpaceContext offerSpaceContext = new OfferSpaceContext();
            UserProfile customer = offerSpaceContext.Customers.FirstOrDefault(custUser => custUser.UserId == id);
            return customer;

        }
    }
}
